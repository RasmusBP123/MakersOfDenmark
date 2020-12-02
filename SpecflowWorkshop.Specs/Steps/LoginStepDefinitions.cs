using Application.Services;
using Application.ViewModels.Account;
using Domain.Abstractions.Repositories;
using Domain.Responses;
using FluentAssertions;
using Infrastructure.Authentication;
using Moq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UnitTests.WorkshopTests;

namespace SpecflowWorkshop.Specs.Steps
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        public AuthServiceProvider _sut;
        private readonly MockerFactory _mocker;
        private readonly Mock<IAuthService> _authServiceMock;
        private readonly Mock<IUserRepository> _userRepoMock;
        public LoginStepDefinitions(ScenarioContext scenarioContext,
                                               MockerFactory mocker,
                                               Mock<IAuthService> authServiceMock,
                                               Mock<IUserRepository> userRepoMock)
        {
            _scenarioContext = scenarioContext;
            _mocker = mocker;
            _authServiceMock = authServiceMock;
            _userRepoMock = userRepoMock;
            _sut = new AuthServiceProvider(_authServiceMock.Object, _mocker.Mapper.Object, _userRepoMock.Object);
        }

        LoginViewModel model;

        [Given("the user exists")]
        public void GivenTheUserIsValid()
        {
            model = new LoginViewModel
            {
                Username = "MyUsername",
                Password = "HejMedDig123!"
            };

            _scenarioContext.Pending();
        }

        Response response;
        [When("user will be logged in")]
        public async Task LoginUserIn()
        {
            _authServiceMock.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(response);
            response = await _sut.Login(model);
        }

        [Then("The result should be true")]
        public void ThenResultShouldBe()
        {
            response.IsSuccess.Should().BeTrue("Because user credentials are correct");
        }
    }
}
