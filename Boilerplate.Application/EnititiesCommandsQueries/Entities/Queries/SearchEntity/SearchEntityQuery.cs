using Boilerplate.Application.Common;
using Boilerplate.Application.Dto.Entity;
using MediatR;

namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Queries.SearchProduct
{
    public record SearchEntityQuery(SearchFilterModel Model) : IRequest<OperationResult<IList<EntityDto>>>;
}
