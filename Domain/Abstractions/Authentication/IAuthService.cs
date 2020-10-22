using Domain;
using Domain.Responses;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication
{
    public interface IAuthService
    {
        Task<Response> RegisterUser(ApplicationUser user, string password);
        Task<IdentityResult> ForgotPassword(string userId, string newPassword);
        Task<Response> Login(string username, string password);
        Task Logout();
    }
}
