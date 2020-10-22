using Application.Services;
using Domain.Abstractions.Repositories;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Threading.Tasks;
using UnitTests.WorkshopTests;
using Xunit;

namespace UnitTests.AccountTests
{
    public class LogoutTests
    {
        private readonly AuthServiceProvider _sut;
        private readonly MockerFactory _mocker;
        private readonly Mock<IAuthService> authServiceMock;
        private readonly Mock<IUserRepository> userRepoMock;
        private readonly Mock<IHttpContextAccessor> ctxMock;
        
        public LogoutTests()
        {
            _mocker = new MockerFactory();
            authServiceMock = new Mock<IAuthService>();
            userRepoMock = new Mock<IUserRepository>();
            ctxMock = new Mock<IHttpContextAccessor>();
            _sut = new AuthServiceProvider(authServiceMock.Object, _mocker.Mapper.Object, userRepoMock.Object);
        }

        [Fact]
        public async Task User_Should_Be_Logged_Out()
        {
            //Arrange
            authServiceMock.Setup(x => x.Logout()).Verifiable();
            await _sut.Logout();

            //Arrange
            authServiceMock.Verify(x => x.Logout(), Times.Once);
        }

    }
}
