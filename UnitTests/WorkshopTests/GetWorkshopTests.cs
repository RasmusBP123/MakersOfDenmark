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
    class GetWorkshopTests
    {
        private readonly WorkshopService _sut;
        private readonly Mock<IWorkshopRepository> workshopRepoMock = new Mock<IWorkshopRepository>();
        private readonly Mock<IDbContext> context = new Mock<IDbContext>();
        private readonly Mock<IMapper> mapper = new Mock<IMapper>();

        public GetWorkshopTests()
        {
            _sut = new WorkshopService(workshopRepoMock.Object, context.Object, mapper.Object);
        }

        public async Task GetWorkshopById()
        {
            //Act
            var workshop = new Workshop();
            workshop.Id = Guid.NewGuid();

            workshopRepoMock.Setup(x => x.GetById(Guid.NewGuid())).ReturnsAsync(workshop);
            //Arrange
            var actual = await _sut.GetById(new Guid("CBB5A18D-8E33-49D7-ED84-08D87509D0DF"));

            //Assert
            Assert.Equal(workshop.Id, actual.Id);
        }

    }
}
