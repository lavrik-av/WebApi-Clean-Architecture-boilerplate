using MediatR;
using Boilerplate.Application.Common;
using Boilerplate.Application.Dto.Entity;

namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Queries.GetProducts
{
    public record GetEntitiesQuery()
        : IRequest<OperationResult<IList<EntityDto>>>;
}
