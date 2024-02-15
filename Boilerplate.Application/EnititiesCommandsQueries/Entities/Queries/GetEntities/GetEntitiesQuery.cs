using MediatR;
using Boilerplate.Application.Common;
using Boilerplate.Application.Dto.Entity;

namespace Boilerplate.Application.EnititiesCommandsQueries.Enteties.Queries.GetEntities
{
    public record GetEntitiesQuery()
        : IRequest<OperationResult<IList<EntityDto>>>;
}
