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
                title = task.ApplicationID,
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

        return Json("");
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
