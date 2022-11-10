using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortalProgramacao.Application.Dtos.Activity;
using PortalProgramacao.Application.Interfaces.Services;
using PortalProgramacao.Domain.Interfaces;
using PortalProgramacao.Web.Models.Activity;

namespace PortalProgramacao.Web.Controllers.Activities;

public class ActivityController : BaseController
{
    private readonly ILogger<ActivityController> _logger;
    private readonly IActivityService _activityService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IActivityTypeRepository _activityTypeRepository;
    private readonly IProcessRepository _processRepository;



    private readonly IMapper _mapper;

    public ActivityController(ILogger<ActivityController> logger, 
        IActivityService activityService, IMapper mapper, IWebHostEnvironment webHostEnvironment,
        IActivityTypeRepository activityTypeRepository, IProcessRepository processRepository)
    {
        _logger = logger;
        _activityService = activityService;
        _mapper = mapper;
        _webHostEnvironment = webHostEnvironment;
        _activityTypeRepository = activityTypeRepository;
        _processRepository = processRepository;
    }

    public IActionResult Index()
    {
        var activities = _activityService.GetAll();
        var model = _mapper.Map<ICollection<ViewActivityModel>>(activities);
        
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
    public IActionResult Add(AddOrEditActivityModel model)
    {
        if(!ModelState.IsValid)
            return View(model);

        var dto = _mapper.Map<ActivityDto>(model);

        _activityService.Add(dto);

        return RedirectToAction("Index", "Activity");
    }

    [HttpGet]
    public IActionResult Edit(ulong id)
    {
        var entity = _activityService.Get(id);
        if(entity != null)
        {
            var model = _mapper.Map<AddOrEditActivityModel>(entity);
            return View(model);
        }

        return NotFound();
    }

    [HttpPost]
    public IActionResult Edit(AddOrEditActivityModel model)
    {
        if(!ModelState.IsValid)
            return View(model);

        var dto = _mapper.Map<ActivityDto>(model);

        _activityService.Edit(dto);

        return RedirectToAction("Index", "Activity");
    }

    [HttpPost]
    public IActionResult Import(IFormFile? excel)
    {
        var errors = new List<string>();
        ActivityImportUtil.ImportActivities(excel, _activityService, errors, _activityTypeRepository, _processRepository);

        return Ok(errors);
    }

    [HttpPost]
    public FileResult Export(ulong[] ids)
    {
        var excelBytes = ActivityExportUtil.Export(_activityService.Get(ids).ToList(), _webHostEnvironment);

        FileResult fr = new FileContentResult(excelBytes, "application/vnd.ms-excel")
        {
            FileDownloadName = string.Format("Export_Atividades_{0}.xlsx", DateTime.Now.ToString("yyMMdd"))
        };

        return fr;
    }

    [HttpDelete]
    public IActionResult Delete(ulong[] ids)
    {
        _activityService.Delete(ids);
        return Ok();
    }

}
