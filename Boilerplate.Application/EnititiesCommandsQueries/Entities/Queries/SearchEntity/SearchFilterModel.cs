using Boilerplate.Application.Common.Filters;

namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Queries.SearchProduct
{
    public class SearchFilterModel
    {
        public IList<SearchTerm> Filters { get; set; } = new List<SearchTerm>();
    }
}
