using Boilerplate.Application.Common.Filters;
using Boilerplate.Application.Common.Filters.Products;

namespace Boilerplate.Application.EnititiesCommandsQueries.Enteties.Queries.GetProductsPaged
{
    public class GetEntitiesPagedModel
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string OrderBy { get; set; } = FieldsConstants.NAME;
        public string Direction { get; set; } = SortingConstants.ASC;
        public bool IncludeJoined { get; set; } = false;

    }
}
