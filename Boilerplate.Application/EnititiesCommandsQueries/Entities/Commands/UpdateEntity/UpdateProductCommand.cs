using Boilerplate.Application.Common;
using Boilerplate.Application.Dto.Entity;
using MediatR;

namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(UpdateProductModel Model)
        : IRequest<OperationResult<EntityDto>>
    {
    }
}
