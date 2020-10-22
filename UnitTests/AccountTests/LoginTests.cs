using Application.Services;
using Application.ViewModels.Account;
using Domain;
using Domain.Abstractions.Repositories;
using Domain.Responses;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitTests.WorkshopTests;
using Xunit;

namespace UnitTests.AccountTests
{
    public class LoginTests
    {
        private readonly AuthServiceProvider _sut;
        private readonly MockerFactory _mocker;
        private readonly Mock<IAuthService> authServiceMock;
        private readonly Mock<IUserRepository> userRepoMock;
        public LoginTests()
        {
            _mocker = new MockerFactory();
            authServiceMock = new Mock<IAuthService>();
            userRepoMock = new Mock<IUserRepository>();
            _sut = new AuthServiceProvider(authServiceMock.Object, _mocker.Mapper.Object, userRepoMock.Object);
        }

        [Fact]
        public async Task User_Should_Login()
        {
            //Arrange
            var loginViewModel = new LoginViewModel
            {
                Username = "MyUsername",
                Password = "HejMedDig123!"
            };

            var response = new Response(true, null, null);
            authServiceMock.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(response);

            //Act
            var actual = await _sut.Login(loginViewModel);

            Assert.True(actual.IsSuccess);
        }
    }
}
