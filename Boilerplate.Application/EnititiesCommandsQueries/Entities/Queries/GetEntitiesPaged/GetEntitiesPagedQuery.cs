using Boilerplate.Application.Common;
using Boilerplate.Application.Dto.Entity;
using MediatR;

namespace Boilerplate.Application.EnititiesCommandsQueries.Enteties.Queries.GetProductsPaged
{
    public record GetEntitiesPagedQuery(GetEntitiesPagedModel Model)
        : IRequest<OperationResultList<IList<EntityDto>>>;
}
