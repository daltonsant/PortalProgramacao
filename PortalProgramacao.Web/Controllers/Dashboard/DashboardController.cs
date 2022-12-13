
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using PortalProgramacao.Application.Dtos.Dashboard;
using PortalProgramacao.Application.Interfaces.Services;
using PortalProgramacao.Web.Models.Dashboard;

namespace PortalProgramacao.Web.Controllers.Dashboard;

public class DashboardController : BaseController
{
    private readonly ILogger<DashboardController> _logger;
    private readonly IDashboardService _dashboardService;
    private readonly IMapper _mapper;

    public DashboardController(ILogger<DashboardController> logger, 
        IDashboardService dashboardService,
        IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
       _dashboardService = dashboardService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Dash(DashboardFilterModel model)
    {
        var dto = _mapper.Map<DashboardFilterModel, DashDto>(model);

        return Json(
            _dashboardService.Getdashboards(dto)
        );
    }

}
