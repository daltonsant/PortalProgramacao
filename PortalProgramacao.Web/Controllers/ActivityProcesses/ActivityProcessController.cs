using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortalProgramacao.Web.Models;

namespace PortalProgramacao.Web.Controllers.ActivityProcesses;

public class ActivityProcessController : BaseController
{
    private readonly ILogger<ActivityProcessController> _logger;

    public ActivityProcessController(ILogger<ActivityProcessController> logger)
    {
        _logger = logger;
    }
    
}
