using Application.Services;
using Application.ViewModels.Account;
using Domain;
using Domain.Abstractions.Repositories;
using Domain.Responses;
using Infrastructure.Authentication;
using Moq;
using System.Threading.Tasks;
using UnitTests.WorkshopTests;
using Xunit;
using FluentAssertions;

namespace UnitTests.AccountTests
{
    public class RegisterTests
    {
        private readonly AuthServiceProvider _sut;
        private readonly MockerFactory _mocker;
        private readonly Mock<IAuthService> authServiceMock;
        private readonly Mock<IUserRepository> userRepoMock;

        public RegisterTests()
        {
            authServiceMock = new Mock<IAuthService>();
            _mocker = _mocker = new MockerFactory();
            userRepoMock = new Mock<IUserRepository>();
            _sut = new AuthServiceProvider(authServiceMock.Object, _mocker.Mapper.Object, userRepoMock.Object);
        }

        [Fact]
        public async Task Should_Create_Account_When_Email_Or_Username_Is_NOT_Taken()
        {
            //Arrange
            var userViewModel = new RegisterAccountViewModel
            {
                UserName = "Rasmus Bak",
                Email = "rasmus@mail.dk",
                FirstName = "Rasmus",
                LastName = "Bak",
                Phonenumber = "28929173",
                Password = "GenericPassword123#"
            };

            var user = new ApplicationUser
            {
                UserName = "Rasmus Bak",
                Email = "rasmus@mail.dk",
                FirstName = "Rasmus",
                LastName = "Bak",
                PhoneNumber = "28929173",
            };

            _mocker.Mapper.Setup(x => x.Map<ApplicationUser>(userViewModel)).Returns(user);
            userRepoMock.Setup(x => x.IsEmailOrUsernameTaken(user)).ReturnsAsync(false);

            var response = new Response(true, null, null);
            authServiceMock.Setup(x => x.RegisterUser(It.IsAny<ApplicationUser>(), userViewModel.Password)).ReturnsAsync(response);

            //Act
            var actual = await _sut.RegisterUser(userViewModel);

            //Assert
            actual.IsSuccess.Should().Be(true, "Because email or username is unique and does not exist already");
            Assert.True(actual.IsSuccess);
        }

        [Fact]
        public async Task Should_Not_Create_User_When_Email_Is_Taken()
        {
            //Arrange
            var userViewModel = new RegisterAccountViewModel
            {
                UserName = "Rasmus Bak",
                Email = "rasmus@mail.dk",
                FirstName = "Rasmus",
                LastName = "Bak",
                Phonenumber = "28929173",
                Password = "GenericPassword123#"
            };

            var user = new ApplicationUser
            {
                UserName = "Rasmus Bak",
                Email = "rasmus@mail.dk",
                FirstName = "Rasmus",
                LastName = "Bak",
                PhoneNumber = "28929173",
            };

            _mocker.Mapper.Setup(x => x.Map<ApplicationUser>(userViewModel)).Returns(user);
            userRepoMock.Setup(x => x.IsEmailOrUsernameTaken(user)).ReturnsAsync(true);

            var response = new Response(false, null, null);
            authServiceMock.Setup(x => x.RegisterUser(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(response);

            //Act
            var actual = await _sut.RegisterUser(userViewModel);

            //Assert
            userRepoMock.VerifyAll();
            Assert.False(actual.IsSuccess);
        }
    }
}
