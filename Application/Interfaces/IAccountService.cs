using Application.ViewModels.Account;
using Domain.Responses;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<Response> RegisterAccount(RegisterAccountViewModel registerAccountModel);
        Task<IdentityResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordModel);
        Task<Response> DeleteAccount(Guid id);
        Task<Response> MakeUserWorkspaceAdmin(Guid userId);
    }
}


