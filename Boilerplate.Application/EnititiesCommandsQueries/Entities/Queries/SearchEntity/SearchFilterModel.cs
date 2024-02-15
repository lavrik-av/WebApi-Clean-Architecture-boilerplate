using Boilerplate.Application.Common.Filters;

namespace Boilerplate.Application.EnititiesCommandsQueries.Enteties.Queries.SearchEntity
{
    public class SearchFilterModel
    {
        public IList<SearchTerm> Filters { get; set; } = new List<SearchTerm>();
    }
}
