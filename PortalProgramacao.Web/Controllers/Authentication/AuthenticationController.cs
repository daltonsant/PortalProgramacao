using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortalProgramacao.Web.Models;

namespace PortalProgramacao.Web.Controllers.Authentication;

public class AuthenticationController : BaseController
{
    private readonly ILogger<AuthenticationController> _logger;

    public AuthenticationController(ILogger<AuthenticationController> logger)
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

}
