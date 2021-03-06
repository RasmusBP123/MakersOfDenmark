﻿using Application.ViewModels.Account;
using Domain.Responses;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthServiceProvider
    {
        Task<Response> RegisterUser(RegisterAccountViewModel registerAccountModel);
        Task<IdentityResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordModel);
        Task<Response> Login(LoginViewModel loginModel);
        Task Logout();
    }
}
