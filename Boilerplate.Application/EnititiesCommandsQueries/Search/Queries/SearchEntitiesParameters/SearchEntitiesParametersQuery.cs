using Boilerplate.Application.Common;
using Boilerplate.Application.Common.Filters.AuxParams;
using MediatR;

namespace Boilerplate.Application.EnititiesCommandsQueries.Search.Queries.SearchEntitiesParameters
{
    public record SearchEntitiesParametersQuery<TEntity, TEntityDto>(AuxParams auxParams) : IRequest<PagedList<TEntityDto>>;
}
