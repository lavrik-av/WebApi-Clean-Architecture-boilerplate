using Microsoft.AspNetCore.Mvc;
using MediatR;
using Boilerplate.Application.Common;

namespace Boilerplate.Application.EnititiesCommandsQueries.Enteties.Commands.DeleteEntity
{
    public record DeleteEntityCommand(DeleteEntityModel Model) : IRequest<OperationResult<EmptyResult>>
    {
    }
}
