using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Authentication;
using Domain;
using Application.ViewModels.Account;
using Application.Interfaces;

namespace MakersOfDenmark.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthServiceProvider authservice;

        public AuthController(IAuthServiceProvider authservice)
        {
            this.authservice = authservice;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginModel) 
        {
            var result = await authservice.Login(loginModel);
            return Ok(result);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccountViewModel account)
        {
            var result = await authservice.RegisterUser(account);
            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await authservice.Logout();
            return Ok();
        }

        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordViewModel forgotPasswordViewModel)
        {
            var result = await authservice.ForgotPassword(forgotPasswordViewModel);
            return Ok(result);
        }

        [HttpPost("promote/{userId}")]
        public async Task<IActionResult> MakeUserWorkspaceAdmin([FromRoute]Guid userId)
        {
            var result = await authservice.MakeUserWorkspaceAdmin(userId);
            return Ok(result);
        }

        [HttpPost("delete/{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var result = await authservice.DeleteUser(userId);
            return Ok(result);
        }
    }
}
