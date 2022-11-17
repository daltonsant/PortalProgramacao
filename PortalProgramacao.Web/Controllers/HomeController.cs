using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalProgramacao.Infrastructure.Identity;
using PortalProgramacao.Infrastructure.Interfaces;
using PortalProgramacao.Web.Models;

namespace PortalProgramacao.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserService _userService;

    public HomeController(ILogger<HomeController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    public IActionResult Index()
    {
        var user = User?.Identity;

        if(user != null && user.IsAuthenticated)
            return RedirectToAction("Index", "Wallet");
        
        return View();
    }

    [HttpPost]
    [Route("/Home/Login/")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var errors = new List<string>();

        model = new LoginModel(){
            UserName = "dpsecin",
            Password = "Abcd*1234"
        };
        ModelState.Clear();
        
        if (!ModelState.IsValid)
        {
            errors.Add("Os campos de usuário e senha precisam ser preenchidos.");
            return Ok(errors);
        }
            
        var user = await _userService.GetUserByUserName(model.UserName);
        
        PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

        if (user != null && passwordHasher
                .VerifyHashedPassword(user, 
                    user.PasswordHash, 
                    model.Password) !=
            PasswordVerificationResult.Failed)
        {
            if(user.IsActive)
            {
                await _userService.LoginUser(user, false);
                return Ok();
            }
        }
        
        errors.Add("Usuário ou senha incorretos");

        return Ok(errors);
    }


    public IActionResult Register()
    {
        return View(new UserModel());
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserModel model)
    {
        if (!ModelState.IsValid) return View(model);
        
        ApplicationUser user = new ApplicationUser();
        IdentityResult userCreated;
            
        user.UserName = model.UserName;
        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.Email = model.Email;

        user.IsActive = true;
            
        if(!_userService.VerifyIfHasRegisteredUsers())
        {
            userCreated = await _userService.CreateUser(user, model.Password);

            if (userCreated.Succeeded)
            {
                await _userService.AddUserInRole(user, "Administrator");
                await _userService.LoginUser(user, false);
                return RedirectToAction("Index", "Home");
            }
        }

        userCreated = await _userService.CreateUser(user, model.Password);

        if (userCreated.Succeeded)
        {
            if(model.IsAdmin)
            {
                await _userService.AddUserInRole(user, "Administrator");
                return RedirectToAction("Index", "Home");
            }

            await _userService.AddUserInRole(user, "User");
            return RedirectToAction("Index", "Home");
        }
        else
        {
            foreach(IdentityError error in userCreated.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
    }


    public IActionResult UpdateUser()
    {
        return Ok();
    }

    public IActionResult UpdateUser(UserModel model)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult ResetPassword(string userId)
    {
        return Ok();
    }

    public async Task<IActionResult> Logout()
    {
        await _userService.Logout();
        return RedirectToAction("Index","Home");
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
