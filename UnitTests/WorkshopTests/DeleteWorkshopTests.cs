using Application.Services;
using AutoMapper;
using Domain;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.WorkshopTests
{
    public class DeleteWorkshopTests
    {
        private readonly WorkshopService _sut;
        private readonly Mock<IWorkshopRepository> workshopRepoMock = new Mock<IWorkshopRepository>();

        private readonly MockerFactory _mocker;

        public DeleteWorkshopTests()
        {
            _mocker = new MockerFactory();  
            _sut = new WorkshopService(workshopRepoMock.Object, _mocker.Context.Object, _mocker.Mapper.Object);
        }

        [Fact]
        public async Task ShouldDeleteWorkshop()
        {
            //Arrange
            var id = new Guid("CBB5A18D-8E33-49D7-ED84-08D87509D0DF");


            workshopRepoMock.Setup(x => x.Delete(id)).Returns(Task.CompletedTask);
            _mocker.Context.Setup(x => x.SaveChangesAsync()).ReturnsAsync(true);

            var workshop = new Workshop
            {
                Id = id,
            };

            workshopRepoMock.Setup(x => x.GetById(id)).ReturnsAsync(workshop);

            //Act
            await _sut.Delete(id);

            var deletedWorkshop = await _sut.GetById(id);

            //Assert
            Assert.Null(deletedWorkshop);
        }

    }
}
