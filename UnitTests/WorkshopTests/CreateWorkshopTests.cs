using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Domain;
using Application.Services;
using Moq;
using Domain.Abstractions.Repositories;
using static Domain.Enums.Enums;
using Application.ViewModels;
using System.Threading.Tasks;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace UnitTests.WorkshopTests
{
    
    public class CreateWorkshopTests
    {
        private readonly WorkshopService _sut;
        private readonly Mock<IWorkshopRepository> workshopRepoMock = new Mock<IWorkshopRepository>();

        private readonly MockerFactory _mocker;

        public CreateWorkshopTests()
        {
            _mocker = new MockerFactory();
            _sut = new WorkshopService(workshopRepoMock.Object, _mocker.Context.Object, _mocker.Mapper.Object);
        }

        [Theory]
        [InlineData("UCL Workshop", "Seebladsgade 31", "5000", "https://ucl.dk", "facebook.com/ucl", WorkshopTypes.Association, AccessType.Membership, "28929173", "12125", null)]
        [InlineData("Aalborg Workshop", "Bredgade 1", "9000", "https://aalborg.dk", "facebook.com/aalborg", WorkshopTypes.Association, AccessType.Other, "20512511", "1254634", null)]
        public async Task ShouldCreateValidWorkshop(string name,
                                              string address,
                                              string zipcode,
                                              string url, 
                                              string facebookLink,
                                              WorkshopTypes type,
                                              AccessType access,
                                              string phoneNumber,
                                              string cvrNumber, 
                                              Guid? schooldId)
        {
            //Arrange
            var workshop = new CreateWorkshopViewModel
            {
                Name = name,
                Address = address,
                Zipcode = zipcode,
                Url = url,
                FacebookLink = facebookLink,
                Type = type,
                Access = access,
                Phone = phoneNumber,
                CvrNumber = cvrNumber,
                SchooldId = schooldId,
            };

            //Act
            _mocker.Context.Setup(x => x.SaveChangesAsync()).ReturnsAsync(true);

            var result = await _sut.Create(workshop);

            //Assert
            Assert.True(result);
        }


    }

}
