using Boilerplate.Application.Common;
using Boilerplate.Application.Dto.Entity;
using MediatR;

namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Commands.CreateProduct
{
    public record CreateEntityCommand(CreateEntityModel Model) 
        : IRequest<OperationResult<EntityDto>>;
}
