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
        Task<IdentityResult> RegisterUser(string username, string password, string email, string firstName, string lastName, string phonenumber);
        Task<IdentityResult> ForgotPassword(string userId, string newPassword);
        Task<IList<string>> GetRoles(string email);
        Task<SignInResult> Login(string username, string password);
        Task Logout();
    }
}
