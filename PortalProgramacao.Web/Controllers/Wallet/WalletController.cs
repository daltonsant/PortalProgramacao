using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortalProgramacao.Web.Models;

namespace PortalProgramacao.Web.Controllers.Wallet;

public class WalletController : BaseController
{
    private readonly ILogger<WalletController> _logger;

    public WalletController(ILogger<WalletController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult List()
    {
        return Ok();
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
