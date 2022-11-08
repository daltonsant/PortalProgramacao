using System.Data;
using System.Diagnostics;
using System.Text;
using ExcelDataReader;
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
        if(!ModelState.IsValid)
            return View(model);

        return View();
    }

    [HttpGet]
    public IActionResult Edit(ulong id)
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
        var errors = new List<string>();
        EmployeeImportUtil.ImportEmployees(excel, null, errors);

        return Ok(errors);
    }


    [HttpDelete]
    public IActionResult Delete(ulong[] ids)
    {
        return Ok();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
