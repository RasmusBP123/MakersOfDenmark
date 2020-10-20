using Application.Services;
using AutoMapper;
using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.WorkshopTests
{
    public class MockerFactory
    {
        public Mock<IDbContext> Context { get; set; }
        public Mock<IMapper> Mapper { get; set; }

        public MockerFactory()
        {
            Context = new Mock<IDbContext>();
            Mapper = new Mock<IMapper>();
        }
    }
}
