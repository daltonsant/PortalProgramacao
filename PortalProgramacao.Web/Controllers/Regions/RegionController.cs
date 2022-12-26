using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortalProgramacao.Web.Models;

namespace PortalProgramacao.Web.Controllers.Regions;

public class RegionController : BaseController
{
    private readonly ILogger<RegionController> _logger;

    public RegionController(ILogger<RegionController> logger)
    {
        _logger = logger;
    }
    
}
