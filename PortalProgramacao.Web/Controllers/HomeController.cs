using System.Diagnostics;
using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalProgramacao.Infrastructure.Identity;
using PortalProgramacao.Infrastructure.Interfaces;
using PortalProgramacao.Web.Models;

namespace PortalProgramacao.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserService _userService;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ILogger<HomeController> logger, 
        IUserService userService, 
        UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _userService = userService;
        _userManager = userManager;
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

    public async Task<IActionResult> Register()
    {
        var userIdentity = User?.Identity;
        if (userIdentity?.Name == null)
            return Unauthorized();

        var loggedUser = await _userService.GetUserByUserName(userIdentity.Name);

        if (loggedUser == null || !await _userManager.IsInRoleAsync(loggedUser, "Administrator"))
            return Unauthorized();

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

        var userIdentity = User?.Identity;
        if (userIdentity?.Name == null)
            return Unauthorized();

        var loggedUser = await _userService.GetUserByUserName(userIdentity.Name);

        if (loggedUser == null || !await _userManager.IsInRoleAsync(loggedUser, "Administrator"))
            return Unauthorized();

        userCreated = await _userService.CreateUser(user, model.Password);

        if (userCreated.Succeeded)
        {
            if(model.IsAdmin)
            {
                await _userService.AddUserInRole(user, "Administrator");
                return RedirectToAction("Index", "Home");
            }

            await _userService.AddUserInRole(user, "Programador");
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

    public async Task<IActionResult> UpdateUser()
    {
        var userIdentity = User?.Identity;
        if (userIdentity?.Name == null)
            return NotFound();

        var user = await _userService.GetUserByUserName(userIdentity.Name);

        if (user == null)
            return NotFound();

        var model = new UpdateUserModel()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };


        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateUser(UpdateUserModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var userIdentity = User?.Identity;
        if (userIdentity?.Name == null)
            return NotFound();

        var user = await _userService.GetUserByUserName(userIdentity.Name);

        if (user == null)
            return NotFound();

        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.Email = model.Email;

        var res = await _userService.UpdateUser(user, model.Password);

        if(res.Succeeded)
            return RedirectToAction("Index", "Home");

        return View(model);
    }

    [Authorize]
    public async Task<IActionResult> ResetUser(string username, bool? isAdmin)
    {
        var userIdentity = User?.Identity;
        if (userIdentity?.Name == null)
            return Unauthorized();

        var loggedUser = await _userService.GetUserByUserName(userIdentity.Name);

        if (loggedUser == null || !await _userManager.IsInRoleAsync(loggedUser, "Administrator"))
            return Unauthorized();

        var user = await _userService.GetUserByUserName(username);

        if (user == null)
            return NotFound();

        if (isAdmin.HasValue)
        {
            // THIS LINE IS IMPORTANT
            await _userManager.RemoveFromRolesAsync(user, new List<string>() { "Administrator", "Programador" });
            if (isAdmin.Value)
                await _userManager.AddToRoleAsync(user, "Administrator");
            else
                await _userManager.AddToRoleAsync(user, "Programador");
        }

        user = await _userService.GetUserByUserName(username);

        await _userService.UpdateUser(user, "Abcd*1234");

        return Ok("Abcd*1234");
    }

    public async Task<IActionResult> ListUsers()
    {
        var list = new List<Tuple<string,string>>();
        var users = _userManager.Users.ToList();

        foreach (var user in users)
        {
            var name = user.FirstName + " " + user.LastName + " - " + user.UserName;
            var action = user.UserName;
            var tuple = new Tuple<string, string>(name, action);
            list.Add(tuple);
        }
        
        return View(list);
    }
    
    public async Task<IActionResult> Logout()
    {
        await _userService.Logout();
        return RedirectToAction("Index","Home");
    }

    [Authorize]
    public IActionResult Admin()
    {
        return View();
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [Route("/Error/{id:length(3,3)}")]
    public IActionResult Error(int id)
    {
        var model = new ErrorViewModel();

        if(id == 500)
        {
            model.Message = "Ocorreu um erro no servidor. Contacte o suporte para solucionar.";
        }
        else if (id == 404)
        {
            model.Message = "Não encontrado.";
        }
        else if (id == 403)
        {
            model.Message = "Não autorizado.";
        }
        else
        {
            model.Message = "Ocorreu um erro na sua requisição.";
        }

        model.StatusCode= id;

        return View(model);
    }
}
