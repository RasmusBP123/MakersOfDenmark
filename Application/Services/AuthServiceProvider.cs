using Application.Interfaces;
using Application.ViewModels.Account;
using AutoMapper;
using Domain;
using Domain.Abstractions.Repositories;
using Domain.Responses;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthServiceProvider : IAuthServiceProvider
    {
        private readonly IAuthService service;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public AuthServiceProvider(IAuthService service, IMapper mapper, IUserRepository userRepository)
        {
            this.service = service;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<Response> Login(LoginViewModel loginModel)
        {
            var response = await service.Login(loginModel.Username, loginModel.Password);

            return response;
        }

        public async Task Logout()
        {
            await service.Logout();
        }

        public async Task<Response> RegisterUser(RegisterAccountViewModel registerAccountModel)
        {
            var user = mapper.Map<ApplicationUser>(registerAccountModel);

            var emailOrUserNameIsTaken = await userRepository.IsEmailOrUsernameTaken(user);
            if(emailOrUserNameIsTaken)
                return new Response(false, null, new List<string> { "Username or email has already been taken" });

            var response = await service.RegisterUser(user, registerAccountModel.Password);
            return response;
        }
        public async Task<IdentityResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordModel)
        {
            var result = await service.ForgotPassword(forgotPasswordModel.Id, forgotPasswordModel.NewPassword);
            return result;
        }
    }
}
