using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortalProgramacao.Web.Models;
using PortalProgramacao.Web.Models.Employee;

namespace PortalProgramacao.Web.Controllers.Employee;

public class EmployeeController : BaseController
{
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Add(AddOrEditEmployeeModel model)
    {
        return View();
    }

    [HttpGet]
    public IActionResult Edit()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Edit(AddOrEditEmployeeModel model)
    {
        return View();
    }

     [HttpPost]
    public IActionResult Import(IFormFile? excel)
    {
        return Ok();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
