using Microsoft.AspNetCore.Mvc;
using MediatR;
using Boilerplate.Application.Common;

namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(DeleteProductModel Model) : IRequest<OperationResult<EmptyResult>>
    {
    }
}
