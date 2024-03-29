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
    public IActionResult List(string? npl, int? month, string? process, ulong? sector)
    {
        ICollection<ViewCalendarModelcs> models = new List<ViewCalendarModelcs>();
        var activitieQuery = _activityRepository.Entities
            .Include(x => x.Npl).ThenInclude(x => x.Sector).Include(x => x.Process).AsQueryable();

        if(sector.HasValue)
        {
            activitieQuery = activitieQuery.Where(x => x.Npl.Sector.Id == sector.Value);
        }

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
            activitieQuery = activitieQuery.Where(x => x.ProgramedDate.HasValue ? x.ProgramedDate.Value.Month == month.Value :
                (x.PlanedDate.HasValue ? x.PlanedDate.Value.Month == month.Value : false));
        }
        var activities = activitieQuery.ToList();

        foreach (var task in activities.Where(x => x.Status != "executada"))
        {
            var taskEvent = new ViewCalendarModelcs() 
            { 
                id = task.Id.ToString(),
                title = task.Process.Name + "-" + task.Npl.Code +"-"+ task.Title + "-" +task.Place.ToString(),
                url = "/Activity/Edit?id=" + task.Id + "&returnToWallet=true",
            };

            if (task.PlanedDate.HasValue)
            {
                taskEvent.start = task.PlanedDate.Value.ToString("yyyy-MM-dd");
                taskEvent.end = task.PlanedDate.Value.AddDays(1).ToString("yyyy-MM-dd");
            }

            if (task.ProgramedDate.HasValue)
            {
                taskEvent.start = task.ProgramedDate.Value.ToString("yyyy-MM-dd");
                taskEvent.end = task.ProgramedDate.Value.AddDays(1).ToString("yyyy-MM-dd");
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


    public IActionResult GetKpis(string? npl, int? month, string? process, ulong? sector)
    {
        //saturacao total do mes
        //array com a saturacao por semana
        // filtrado pr npl, mes, processo
        var activityQuery = _activityRepository.Entities
            .Include(x => x.Npl).ThenInclude(x => x.Sector).Include(x => x.Process).AsQueryable();

        if(sector.HasValue)
        {
            activityQuery = activityQuery.Where(x => x.Npl.Sector.Id == sector.Value);
        }

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

        activityQuery = activityQuery.Where(x => x.ProgramedDate.HasValue ? x.ProgramedDate.Value.Month == m :
            (x.PlanedDate.HasValue ? x.PlanedDate.Value.Month == m : false));

        var activities = activityQuery.ToList();

        var employeeQuery = _employeeRepository.Entities.Include(x => x.Npl).ThenInclude(x => x.Sector)
            .Include(x => x.EnabledProcesses).ThenInclude(x => x.Process)
            .Include(x => x.MonthDayCounts).AsQueryable();
        
        if(sector.HasValue)
        {
            employeeQuery = employeeQuery.Where(x => x.Npl.Sector.Id == sector.Value);
        }

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
            var empContrib = 7.5M * days;
            
            if(string.IsNullOrEmpty(process) || process == "SE")
                hhAvailableSE += 
                    empContrib * (emp.EnabledProcesses
                    .FirstOrDefault(x => x.Process.Name == "SE")?.Percentage/100.0M ?? decimal.Zero);
            if(string.IsNullOrEmpty(process) || process == "LT")
                hhAvailableLT +=
                    empContrib * (emp.EnabledProcesses
                    .FirstOrDefault(x => x.Process.Name == "LT")?.Percentage/100.0M ?? decimal.Zero);
            if(string.IsNullOrEmpty(process) || process == "AUT")
                hhAvailableAUT +=
                    empContrib * (emp.EnabledProcesses
                    .FirstOrDefault(x => x.Process.Name == "AUT")?.Percentage/100.0M ?? decimal.Zero);
            if(string.IsNullOrEmpty(process) || process == "TLE")
                hhAvailableTLE +=
                    empContrib * (emp.EnabledProcesses
                    .FirstOrDefault(x => x.Process.Name == "TLE")?.Percentage/100.0M ?? decimal.Zero);
        }
        
        hhAvailable += hhAvailableSE + hhAvailableLT + hhAvailableAUT + hhAvailableTLE;

        decimal hhNec = decimal.Zero;
        decimal hhNecSE = decimal.Zero;
        decimal hhNecLT = decimal.Zero;
        decimal hhNecAUT = decimal.Zero;
        decimal hhNecTLE = decimal.Zero;

        foreach( var act in  activities)
        {
            var actHH = (act.HeadCount * act.Hours) + act.ComuteTime;
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
    
}
