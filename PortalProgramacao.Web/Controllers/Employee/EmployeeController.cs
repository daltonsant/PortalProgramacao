using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PortalProgramacao.Application.Dtos.Employee;
using PortalProgramacao.Application.Interfaces.Services;
using PortalProgramacao.Web.Models;
using PortalProgramacao.Web.Models.Employee;

namespace PortalProgramacao.Web.Controllers.Employee;

public class EmployeeController : BaseController
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IEmployeeService _employeeService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    private readonly IMapper _mapper;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
    {
        _logger = logger;
        _employeeService = employeeService;
        _mapper = mapper;
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        var employees = _employeeService.GetAll();
        var model = _mapper.Map<ICollection<ViewEmployeeModel>>(employees);
        
        return View(model);
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

        var dto = _mapper.Map<EmployeeDto>(model);

        _employeeService.Add(dto);

        return RedirectToAction("Index", "Employee");
    }

    [HttpGet]
    public IActionResult Edit(ulong id)
    {
        var entity = _employeeService.Get(id);
        if(entity != null)
        {
            var model = _mapper.Map<AddOrEditEmployeeModel>(entity);
            return View(model);
        }

        return NotFound();
    }

    [HttpPost]
    public IActionResult Edit(AddOrEditEmployeeModel model)
    {
        if(!ModelState.IsValid)
            return View(model);

        var dto = _mapper.Map<EmployeeDto>(model);

        _employeeService.Edit(dto);

        return RedirectToAction("Index", "Employee");
    }

    [HttpPost]
    public IActionResult Import(IFormFile? excel)
    {
        var errors = new List<string>();
        EmployeeImportUtil.ImportEmployees(excel, _employeeService, errors);

        return Ok(errors);
    }

    [HttpPost]
    public FileResult Export(ulong[] ids)
    {
        var excelBytes = EmployeeExportUtil.Export(_employeeService.Get(ids).ToList(), _webHostEnvironment);

        FileResult fr = new FileContentResult(excelBytes, "application/vnd.ms-excel")
        {
            FileDownloadName = string.Format("Export_Colaboradores_{0}.xlsx", DateTime.Now.ToString("yyMMdd"))
        };

        return fr;
    }

    [HttpDelete]
    public IActionResult Delete(ulong[] ids)
    {
        _employeeService.Delete(ids);
        return Ok();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
