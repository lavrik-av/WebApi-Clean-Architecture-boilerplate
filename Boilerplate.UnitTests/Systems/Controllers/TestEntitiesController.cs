using Autofac;
using Boilerplate.Application.EnititiesCommandsQueries.Enteties.Queries.GetProduct;
using Boilerplate.Application.Interfaces;
using Boilerplate.UnitTests.Helpers;
using Boilerplate.WebApi.Controllers;
using FluentAssertions;
using MediatR;
using Moq;
using System.Reflection;

namespace Boilerplate.UnitTests.Systems.Controllers
{
    public class TestEntitiesController
    {

        [Fact]
        internal async Task GetEntities_OnSuccess()
        {
            //Arrange
            var builder = DependencyInjection.RegisterServices();
            var sender = DependencyInjection.BuildMediatr(builder);

            //var sender = new Mock<ISender>();
            var generigTypeMediator = new Mock<IGenericTypeMediator>();

            var sut = new EntitiesController(sender, generigTypeMediator.Object);

            //Act
            var result = await sut.GetEntities();

            //Assert

            result.Should().Be(200);
        }
    }
}
