using Boilerplate.Application.Common;
using Boilerplate.Application.Dto.Entity;
using MediatR;

namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Queries.GetProductsPaged
{
    public record GetEntitiesPagedQuery(GetEntitiesPagedModel Model)
        : IRequest<OperationResultList<IList<EntityDto>>>;
}
