using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Authentication;
using Domain;

namespace MakersOfDenmark.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService authservice;

        public AccountController(IAuthService authservice)
        {
            this.authservice = authservice;
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            //var result = await authservice.Login();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password)
        {
            var result = await authservice.CreateUser(username, password);
            return Ok();
        }
    }
}
