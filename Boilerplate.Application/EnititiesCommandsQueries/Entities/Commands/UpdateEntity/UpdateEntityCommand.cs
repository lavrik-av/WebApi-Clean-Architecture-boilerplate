using Boilerplate.Application.Common;
using Boilerplate.Application.Dto.Entity;
using MediatR;

namespace Boilerplate.Application.EnititiesCommandsQueries.Enteties.Commands.UpdateEntity
{
    public record UpdateEntityCommand(UpdateEntityModel Model)
        : IRequest<OperationResult<EntityDto>>
    {
    }
}
