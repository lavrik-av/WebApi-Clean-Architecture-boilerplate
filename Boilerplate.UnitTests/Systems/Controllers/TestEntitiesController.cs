using Boilerplate.Application.Dto.Entity;
using Boilerplate.Application.Interfaces;
using Boilerplate.UnitTests.Helpers;
using Boilerplate.WebApi.Controllers;
using FluentAssertions;
using Moq;

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

            var generigTypeMediator = new Mock<IGenericTypeMediator>();

            var sut = new EntitiesController(sender, generigTypeMediator.Object);

            //Act
            var result = await sut.GetEntities();
            IList<EntityDto>? data;

            if (result.Data == null)
            {
                result.Data.Should().NotBeEmpty();
            }
            else
            {
                data = result.Data;

                result.Data
                    .Should()
                    .NotBeEmpty()
                    .And.HaveCountGreaterThan(0)
                    .And.ContainItemsAssignableTo<EntityDto>();
            }
        }
    }
}
