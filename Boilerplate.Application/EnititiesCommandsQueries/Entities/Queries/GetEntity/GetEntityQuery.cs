using MediatR;
using Boilerplate.Application.Dto.Entity;
using Boilerplate.Application.Common;

namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Queries.GetProduct
{
    public record GetEntityQuery(GetEntityModel Model) 
        : IRequest<OperationResult<EntityDto>>
    {
    }
}
