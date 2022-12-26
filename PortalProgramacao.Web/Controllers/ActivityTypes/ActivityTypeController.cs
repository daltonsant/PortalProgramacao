using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortalProgramacao.Web.Models;

namespace PortalProgramacao.Web.Controllers.ActivityTypes;
public class ActivityTypeController : BaseController
{
    private readonly ILogger<ActivityTypeController> _logger;

    public ActivityTypeController(ILogger<ActivityTypeController> logger)
    {
        _logger = logger;
    }
}
