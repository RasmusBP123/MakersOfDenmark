using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Authentication
{
    public interface IAuthService
    {
        Task<IdentityResult> CreateUser(ApplicationUser user);
        Task<IdentityResult> ForgotPassword(ApplicationUser user, string password, string newPassword);
        Task<IList<string>> GetRoles(string email);
        Task<SignInResult> Login(ApplicationUser user, string password);
        Task Logout();
    }
}
