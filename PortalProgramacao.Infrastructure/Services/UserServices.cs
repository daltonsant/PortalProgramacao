using Microsoft.AspNetCore.Identity;
using PortalProgramacao.Infrastructure.Data.Context;
using PortalProgramacao.Infrastructure.Identity;
using PortalProgramacao.Infrastructure.Interfaces;

namespace PortalProgramacao.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ApplicationContext _context;

    public UserService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ApplicationContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    public async Task<IdentityResult> CreateUser(ApplicationUser user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task AddUserInRole(ApplicationUser user, string role)
    {
        await _userManager.AddToRoleAsync(user, role);
    }

    public bool VerifyIfHasRegisteredUsers()
    {
        return _context.Set<ApplicationUser>().Any();
    }

    public async Task LoginUser(ApplicationUser user, bool isToRemember)
    {
        await _signInManager.SignInAsync(user, isToRemember);
    }

    public async Task<ApplicationUser?> GetUserByUserName(string username)
    {
        return await _userManager.FindByNameAsync(username);
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

    public Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword)
    {
        return _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
    }

    public async Task<IdentityResult> UpdateUser(ApplicationUser user, string? newPassword)
    {
        if (!string.IsNullOrEmpty(newPassword))
        {
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _userManager.ResetPasswordAsync(user, token, newPassword);
        }
        
        return await _userManager.UpdateAsync(user);
    }

    public IQueryable<ApplicationUser> Users
    {
        get
        {
            return _context.Set<ApplicationUser>().AsQueryable();
        }
    }
}