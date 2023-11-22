using Boilerplate.Application.Common.Filters.SearchExpressionBuilders;

namespace Boilerplate.Application.Common.Filters.AuxParams
{
    public class AuxParams
    {
        public IList<SearchTerm> SearchTerms { get; set; } = new List<SearchTerm>();
        public PaginationParam? PaginationParam { get; set; } = new PaginationParam();
        public SortingParam? SortingParam { get; set; } = new SortingParam();
        public string[]? IncludeParam { get; set; } = new string[0];
    }
}
