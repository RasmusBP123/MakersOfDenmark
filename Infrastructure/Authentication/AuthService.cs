﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
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

    public async Task<IdentityResult> CreateUser(string username, string password, string email, string firstname, string lastname)
    {
        ApplicationUser user = new ApplicationUser
        {
            UserName = username,
            Email = email,
            FirstName = firstname,
            LastName = lastname,
            
        };
        var result = await _userManager.CreateAsync(user, password);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "USER");
            if (user.UserName.StartsWith("admin"))
            {
                await _userManager.AddToRoleAsync(user, "ADMIN");
            }
        }

        return null;
    }

    public async Task<IdentityResult> ForgotPassword(ApplicationUser user, string password, string newPassword)
    {
        return await _userManager.ResetPasswordAsync(user, password, newPassword);
    }

    public async Task<IList<string>> GetRoles(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var roles = await _userManager.GetRolesAsync(user);
        return roles;
    }

    public async Task<SignInResult> Login(string username, string password)
    {
        ApplicationUser user = new ApplicationUser
        {
            UserName = username,
            Email = email,
            FirstName = firstname,
            LastName = lastname,

        };
        var userbyemail = await _userManager.FindByEmailAsync("");
        if (userbyemail == null)
        {
            return new SignInResult();
        }
        var result = await _signInManager.PasswordSignInAsync(userbyemail, password, false, false);
        return result;
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }
}