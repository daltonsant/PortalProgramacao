using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalProgramacao.Domain.Interfaces;
using PortalProgramacao.Web.Models;
using PortalProgramacao.Web.Models.Wallet;

namespace PortalProgramacao.Web.Controllers.Wallet;

public class WalletController : BaseController
{
    private readonly ILogger<WalletController> _logger;
    private readonly IActivityRepository _activityRepository;
    private readonly IEmployeeRepository _employeeRepository;


    public WalletController(ILogger<WalletController> logger, IActivityRepository activityRepository, IEmployeeRepository employeeRepository)
    {
        _logger = logger;
        _activityRepository = activityRepository;
        _employeeRepository = employeeRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult List(string? npl, int? month, string? process)
    {
        ICollection<ViewCalendarModelcs> models = new List<ViewCalendarModelcs>();
        var activitieQuery = _activityRepository.Entities
            .Include(x => x.Npl).Include(x => x.Process).AsQueryable();

        if(!string.IsNullOrEmpty(npl) )
        {
            activitieQuery = activitieQuery.Where(x => x.Npl.Code== npl);
        }

        if(!string.IsNullOrEmpty(process) )
        {
            activitieQuery = activitieQuery.Where(x => x.Process.Name == process);
        }

        if (month.HasValue)
        {
            activitieQuery = activitieQuery.Where(x => x.PlanedDate.HasValue ? x.PlanedDate.Value.Month == month : false);
        }
        var activities = activitieQuery.ToList();

        foreach (var task in activities)
        {
            var taskEvent = new ViewCalendarModelcs() 
            { 
                id = task.Id.ToString(),
                title = task.Process.Name + "-" + task.Npl.Code + task.Id.ToString(),
                url = "/Activity/Edit/" + task.Id,
            };

            if (task.PlanedDate.HasValue)
            {
                taskEvent.start = task.PlanedDate.Value.ToString("yyyy-MM-dd");
                taskEvent.end = task.PlanedDate.Value.AddDays(1).ToString("yyyy-MM-dd");
            }

            if (task.DueDate.HasValue && task.DueDate.Value == DateTime.Today)
            {
                taskEvent.className = "event-attention";
            }

            if (task.DueDate.HasValue && task.DueDate.Value < DateTime.Today)
            {
                taskEvent.className = "event-late";
            }

            models.Add(taskEvent);
        }

        return Json(models);
    }


    public IActionResult GetKpis(string? npl, int? month, string? process)
    {
        //saturacao total do mes
        //array com a saturacao por semana
        // filtrado pr npl, mes, processo
        var activityQuery = _activityRepository.Entities
            .Include(x => x.Npl).Include(x => x.Process).AsQueryable();

        if (!string.IsNullOrEmpty(npl))
        {
            activityQuery = activityQuery.Where(x => x.Npl.Code == npl);
        }

        if (!string.IsNullOrEmpty(process))
        {
            activityQuery = activityQuery.Where(x => x.Process.Name == process);
        }

        var m = 0;
        if (month.HasValue)
        {
            m = month.Value;
        }
        else
        {
            m = DateTime.Now.Month;
        }

        activityQuery = activityQuery.Where(x => x.PlanedDate.HasValue ? x.PlanedDate.Value.Month == m : false);

        var activities = activityQuery.ToList();

        var employeeQuery = _employeeRepository.Entities.Include(x => x.Npl)
            .Include(x => x.EnabledProcesses).ThenInclude(x => x.Process)
            .Include(x => x.MonthDayCounts).AsQueryable();

        if (!string.IsNullOrEmpty(npl))
        {
            employeeQuery = employeeQuery.Where(x => x.Npl.Code == npl);
        }

        if (!string.IsNullOrEmpty(process))
        {
            employeeQuery = employeeQuery.Where(x => x.EnabledProcesses.Any(y => y.Process.Name == process && y.Percentage > decimal.Zero));
        }
        
        employeeQuery = employeeQuery.Where(x => x.MonthDayCounts.Any(y => y.Month == m && y.NumberOfDays > 0));

        decimal hhAvailable = decimal.Zero;
        decimal hhAvailableSE = decimal.Zero;
        decimal hhAvailableLT = decimal.Zero;
        decimal hhAvailableAUT = decimal.Zero;
        decimal hhAvailableTLE = decimal.Zero;

        foreach ( var emp in employeeQuery)
        {
            var days = emp.MonthDayCounts.FirstOrDefault(emp=> emp.Month == m)?.NumberOfDays ?? decimal.Zero;
            var empContrib = 8.0M * days;
            hhAvailable += empContrib;
            hhAvailableSE += 
                empContrib * (emp.EnabledProcesses
                .FirstOrDefault(x => x.Process.Name == "SE")?.Percentage/100.0M ?? decimal.Zero);
            hhAvailableLT +=
                empContrib * (emp.EnabledProcesses
                .FirstOrDefault(x => x.Process.Name == "LT")?.Percentage/100.0M ?? decimal.Zero);
            hhAvailableAUT +=
                empContrib * (emp.EnabledProcesses
                .FirstOrDefault(x => x.Process.Name == "AUT")?.Percentage/100.0M ?? decimal.Zero);
            hhAvailableTLE +=
                empContrib * (emp.EnabledProcesses
                .FirstOrDefault(x => x.Process.Name == "TLE")?.Percentage/100.0M ?? decimal.Zero);

        }

        decimal hhNec = decimal.Zero;
        decimal hhNecSE = decimal.Zero;
        decimal hhNecLT = decimal.Zero;
        decimal hhNecAUT = decimal.Zero;
        decimal hhNecTLE = decimal.Zero;

        foreach( var act in  activities)
        {
            var actHH = act.HeadCount * (act.Hours + act.ComuteTime);
            hhNec += actHH;
            if (act.Process.Name == "SE")
                hhNecSE += actHH;
            if(act.Process.Name =="LT")
                hhNecLT+= actHH;
            if(act.Process.Name == "AUT")
                hhNecAUT += actHH;
            if(act.Process.Name == "TLE")
                hhNecTLE+= actHH;
        }

        return Json(new 
            {
                dispTot = hhAvailable,
                necTot = hhNec,
                dispSE = hhAvailableSE,
                necSE = hhNecSE,
                dispLT = hhAvailableLT,
                necLT = hhNecLT,
                dispAUT = hhAvailableAUT,
                necAUT = hhNecAUT,
                dispTLE = hhAvailableTLE,
                necTLE = hhNecTLE,
        });
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
