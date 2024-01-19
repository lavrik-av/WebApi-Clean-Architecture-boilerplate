using Boilerplate.Application.Common.Filters;
using Boilerplate.Application.Common.Filters.SearchHandlers;
using Boilerplate.Application.Common.Filters.SearchHandlers.HandlersFactory;

namespace Boilerplate.Application.Common.Extensions
{
    public static class SearchExtensions
    {
        internal static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, IList<SearchTerm> filters)
        {
            foreach (var searchHandler in filters.GetSearchHandlers())
            {
                query = searchHandler.ApplyFilterToQuery(query);
            }

            return query;
        }

        private static IList<BaseSearchHandler> GetSearchHandlers(this IList<SearchTerm> searchTerms)
        {
            var searchHandlers = new List<BaseSearchHandler>();

            foreach (var term in searchTerms)
            {
                searchHandlers.Add(SearchHandlerFactory.GetSearchHandler(term));
            }

            return searchHandlers;
        }
    }
}
