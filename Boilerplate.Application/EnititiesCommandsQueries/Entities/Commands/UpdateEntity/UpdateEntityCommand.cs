using Boilerplate.Application.Common;
using Boilerplate.Application.Dto.Entity;
using MediatR;

namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Commands.UpdateProduct
{
    public record UpdateEntityCommand(UpdateEntityModel Model)
        : IRequest<OperationResult<EntityDto>>
    {
    }
}
