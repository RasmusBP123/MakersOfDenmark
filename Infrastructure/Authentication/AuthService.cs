using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Http;
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

    public async Task<IdentityResult> RegisterUser(string username, string password, string email, string firstname, string lastname, string phonenumber)
    {
        ApplicationUser user = new ApplicationUser
        {
            UserName = username,
            Email = email,
            FirstName = firstname,
            LastName = lastname,
            PhoneNumber = phonenumber
        };

        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "USER");
        }

        return result;
    }

    public async Task<IdentityResult> ForgotPassword(string userId, string newPassword)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
        return result;
    }

    public async Task<IList<string>> GetRoles(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var roles = await _userManager.GetRolesAsync(user);
        return roles;
    }

    public async Task<SignInResult> Login(string username, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(username, password, true, false);
        return result;
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

}