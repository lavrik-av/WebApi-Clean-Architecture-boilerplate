using Boilerplate.Application.Interfaces;
using Boilerplate.WebApi.Controllers;
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
        internal void GetEntities_OnSuccess()
        {
            //Arrange
            // set up the needed dependency
            // ISender sender, IGenericTypeMediator genericTypeMediator

            var sender = new Mock<ISender>();
            var generigTypeMediator = new Mock<IGenericTypeMediator>();

            var sut = new EntitiesController(sender.Object, generigTypeMediator.Object);

            //Act
            sut.GetEntities();

            //Assert
        }
    }
}
