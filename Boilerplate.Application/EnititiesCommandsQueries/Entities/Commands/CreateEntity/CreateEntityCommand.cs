using Boilerplate.Application.Common;
using Boilerplate.Application.Dto.Entity;
using MediatR;

namespace Boilerplate.Application.EnititiesCommandsQueries.Enteties.Commands.CreateEntity
{
    public record CreateEntityCommand(CreateEntityModel Model) 
        : IRequest<OperationResult<EntityDto>>;
}
