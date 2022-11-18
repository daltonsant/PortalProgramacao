using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortalProgramacao.Web.Models;

namespace PortalProgramacao.Web.Controllers.Users;

public class UserController : BaseController
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
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
