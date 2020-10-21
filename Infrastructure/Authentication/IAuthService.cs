using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Authentication
{
    public interface IAuthService
    {
        Task<IdentityResult> CreateUser(string username, string password);
        Task<IdentityResult> ForgotPassword(ApplicationUser user, string password, string newPassword);
        Task<IList<string>> GetRoles(string email);
        Task<SignInResult> Login(string username, string password);
        Task Logout();
    }
}
