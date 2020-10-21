using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Authentication;
using Domain;
using Application.ViewModels.Account;

namespace MakersOfDenmark.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAuthService authservice;

        public AccountController(IAuthService authservice)
        {
            this.authservice = authservice;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginModel) 
        {
            var result = await authservice.Login(loginModel.Username, loginModel.Password);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return BadRequest(result.Succeeded);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccountViewModel account)
        {
            var result = await authservice.RegisterUser(account.Username, 
                                                        account.Password,
                                                        account.Email, 
                                                        account.Firstname,
                                                        account.Lastname, 
                                                        account.Phonenumber);
            return Ok();
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
            var result = await authservice.ForgotPassword(forgotPasswordViewModel.Id,
                                                          forgotPasswordViewModel.NewPassword);
            return Ok();
        }
    }
}
