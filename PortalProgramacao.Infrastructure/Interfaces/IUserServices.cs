using Microsoft.AspNetCore.Identity;
using PortalProgramacao.Infrastructure.Identity;

namespace PortalProgramacao.Infrastructure.Interfaces;

public interface IUserService
{
    Task<IdentityResult> CreateUser(ApplicationUser user, string password);
    Task AddUserInRole(ApplicationUser user, string role);
    bool VerifyIfHasRegisteredUsers();
    Task LoginUser(ApplicationUser user, bool isToRemember);
    Task<ApplicationUser?> GetUserByUserName(string username);
    Task Logout();
    Task<IdentityResult> ChangePasswordAsync(ApplicationUser user, string currentPassword, string newPassword);
    Task<IdentityResult> UpdateUser(ApplicationUser user, string newPassword);
    IQueryable<ApplicationUser> Users { get; }
}