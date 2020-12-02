using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain;
using Domain.Responses;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<Response> RegisterUser(ApplicationUser user, string password)
    {

        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
            await _userManager.AddToRoleAsync(user, RoleProvider.User);

        var response = new Response(result.Succeeded, null, result.Errors.Select(x => x.Description).ToList());
        return response;
    }

    public async Task<IdentityResult> ForgotPassword(string userId, string newPassword)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
        return result;
    }

    public async Task<Response> Login(string username, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(username, password, true, false);
        return new Response(result.Succeeded, null, null);
    }

    public async Task<IdentityResult> DeleteUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var result = await _userManager.DeleteAsync(user);

        return result;
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<Response> MakeUserWorkspaceAdmin(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
            return new Response(false, null, new List<string> { "User was not found" });

        var result = await _userManager.AddToRoleAsync(user, RoleProvider.WorkspaceAdmin);
        return new Response(result.Succeeded, null, result.Errors.Select(x => x.Description).ToList());
    }

    protected static class RoleProvider
    {
        public static string User { get; } = "User";
        public static string Admin { get; } = "Admin";
        public static string WorkspaceAdmin { get; } = "WorkspaceAdmin";
    } 
}
