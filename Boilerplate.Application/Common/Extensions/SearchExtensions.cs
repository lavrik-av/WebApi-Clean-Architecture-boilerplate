using Boilerplate.Application.Common.Filters;
using Boilerplate.Application.Common.Filters.Products;
using Boilerplate.Application.Common.Filters.SearchHandlers;

namespace Boilerplate.Application.Common.Extensions
{
    public static class SearchExtensions
    {
        public static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, IList<SearchTerm> filters)
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
                searchHandlers.Add(GetSearchHandler(term));
            }

            return searchHandlers;

        }

        private static  BaseSearchHandler GetSearchHandler(SearchTerm searchTerm)
        {
            BaseSearchHandler handler = new TextSearchHandler();

            switch (searchTerm.Field.ToUpper())
            {
                case FieldsConstants.NAME:
                case FieldsConstants.DESCRIPTION:
                case ProductFieldsConstants.SKU:

                    handler = CreateSearchHandler<TextSearchHandler, string>(searchTerm, searchTerm.Term, null);
                    break;

                case ProductFieldsConstants.PRICE:

                    handler = CreateSearchHandler<NumericSearchHandler, decimal>(searchTerm, searchTerm.Term.ConvertToDecimalValue(), 0);
                    break;

                case ProductFieldsConstants.QUANTITY:

                    handler = CreateSearchHandler<IntegerSearchHandler, int>(searchTerm, searchTerm.Term.ConvertToIntValue(), 0);
                    break;

                case FieldsConstants.CREATED:
                    handler = CreateSearchHandler<DatesSearchHandler, DateTime>(searchTerm, searchTerm.Term.ConvertToDateTimeValue(), searchTerm.TermAdd.ConvertToDateTimeValue());
                    break;

                default:
                    throw new NotImplementedException($"The field {searchTerm.Field.ToUpper()} does not exist on the Products table");
            }

            return handler;
        }

        private static T CreateSearchHandler<T, K>(SearchTerm searchTerm, K value, K value2 )
        {

            var fieldName = searchTerm.Field.ToUpper().Substring(0,1) + searchTerm.Field.ToLower().Substring(1);

            Type type = typeof(T);
            var handlerConstructor = type.GetConstructor(new Type[] {});
            var handler = handlerConstructor.Invoke(new object[] {});

            type.GetProperty("FieldName").SetValue(handler, fieldName);
            type.GetProperty("Comparator").SetValue(handler, searchTerm.Comparator);

            if (typeof(T) != typeof(DatesSearchHandler))
            {
                type.GetProperty("SearchTerm").SetValue(handler, value);
            }
            else
            {
                type.GetProperty("DateFrom").SetValue(handler, value);
                type.GetProperty("DateTo").SetValue(handler, value2);
            }

            return (T)handler;
        }

        private static decimal ConvertToDecimalValue(this string value)
        { 
            return decimal.Round(decimal.Parse((string)value), 2);
        }

        private static int ConvertToIntValue(this string value)
        {
            return int.Parse((string)value);
        }

        private static DateTime ConvertToDateTimeValue(this string value)
        {
            return DateTime.Parse((string)value);
        }

    }
}
