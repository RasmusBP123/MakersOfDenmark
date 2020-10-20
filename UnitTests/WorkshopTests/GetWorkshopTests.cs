﻿using Application.Services;
using Application.ViewModels.Workshop;
using AutoMapper;
using Domain;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.WorkshopTests
{
    public class GetWorkshopTests
    {
        private readonly WorkshopService _sut;
        private readonly Mock<IWorkshopRepository> workshopRepoMock = new Mock<IWorkshopRepository>();

        private readonly MockerFactory _mocker;

        public GetWorkshopTests()
        {
            _mocker = new MockerFactory();
            _sut = new WorkshopService(workshopRepoMock.Object, _mocker.Context.Object, _mocker.Mapper.Object);
        }

        [Fact]
        public async Task ShouldGetAllWorkshops()
        {
            //Arrange
            var workshops = new List<Workshop>
            {
                new Workshop
                {
                    Id = Guid.NewGuid(),
                    Name = "My workshop",
                },
                new Workshop
                {
                    Id = Guid.NewGuid(),
                    Name = "Ucl Fablab",
                },
                new Workshop
                {
                    Id = Guid.NewGuid(),
                    Name = "Aalborg Fablab",
                },
            };

            var expected = new List<GetListWorkshopViewModel>
            {
                new GetListWorkshopViewModel
                {
                    Id = Guid.NewGuid(),
                    Name = "My workshop",
                },
                new GetListWorkshopViewModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Ucl Fablab",
                },
                new GetListWorkshopViewModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Aalborg Fablab",
                },
            };

            workshopRepoMock.Setup(x => x.GetAll()).ReturnsAsync(workshops);
            _mocker.Mapper.Setup(x => x.Map<IEnumerable<GetListWorkshopViewModel>>(workshops)).Returns(expected);

            //Act
            var actual = await _sut.GetAll();

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(expected[0].Name, actual.ToList()[0].Name);
            Assert.Equal(expected[0].Id, actual.ToList()[0].Id);
            Assert.Equal(expected.Count(), actual.Count());
        }

        [Fact]
        public async Task ShouldGetWorkshopById()
        {
            var id = new Guid("CBB5A18D-8E33-49D7-ED84-08D87509D0DF");

            //Act
            var workshop = new Workshop()
            {
                Id = id,
            };

            var viewModel = new GetSingleWorkshopViewModel()
            {
                Id = id
            };

            workshopRepoMock.Setup(x => x.GetById(workshop.Id)).ReturnsAsync(workshop);
            _mocker.Mapper.Setup(x => x.Map<GetSingleWorkshopViewModel>(workshop)).Returns(viewModel);

            //Arrange
            var actual = await _sut.GetById(id);

            //Assert
            Assert.NotNull(actual);
            Assert.Equal(workshop.Id, actual.Id);
        }

        [Fact]
        public async Task ShouldReturnNullWhenWorkshopIdIsNull()
        {
            var id = new Guid();

            var actual = await _sut.GetById(id);
            Assert.Null(actual);
        }

    }
}
