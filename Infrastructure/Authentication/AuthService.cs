using System.Collections.Generic;
using System.Linq;
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
        {
            await _userManager.AddToRoleAsync(user, "USER");
        }

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

    public Task<SignInResult> Login(ApplicationUser user, string password)
    {
        throw new System.NotImplementedException();
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }
}