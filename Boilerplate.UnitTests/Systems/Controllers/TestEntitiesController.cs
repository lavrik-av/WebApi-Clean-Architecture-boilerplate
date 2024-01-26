using Boilerplate.Application.Interfaces;
using Boilerplate.WebApi.Controllers;
using FluentAssertions;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boilerplate.UnitTests.Systems.Controllers
{
    public class TestEntitiesController
    {
        [Fact]
        internal async void GetEntities_OnSuccess()
        {
            //Arrange
            // set up the needed dependency
            // ISender sender, IGenericTypeMediator genericTypeMediator

            var sender = new Mock<ISender>();
            var generigTypeMediator = new Mock<IGenericTypeMediator>();

            var sut = new EntitiesController(sender.Object, generigTypeMediator.Object);

            //Act
            var result = await sut.GetEntities();

            //Assert

            result.Should().Be(200);
        }
    }
}
