using Boilerplate.Application.Common.Constants.Common;
using Boilerplate.Application.Common.Filters;
using Boilerplate.Application.Common.Filters.AuxParams;
using Boilerplate.Application.Common.Filters.SearchExpressionBuilders;

namespace Boilerplate.Application.Common.Extensions
{
    public static class SearchExtensionsAux
    {
        public static IQueryable<TEntity> ApplyFiltersAux<TEntity>(this IQueryable<TEntity> query, IList<SearchTerm> searchTerms)
        {

            if(searchTerms.Any())
            {
                foreach ( BaseExpressionBuilder builder in GetExpressionBuilders(searchTerms))
                { 
                    query = builder.ApplyFilterToQuery(query);
                }
            }

            return query;
        }

        private static IList<BaseExpressionBuilder> GetExpressionBuilders(IList<SearchTerm> searchTerms)
        {
            IList<BaseExpressionBuilder> builders = new List<BaseExpressionBuilder>();

            foreach (SearchTerm term in searchTerms) 
            {
                builders.Add(GetBulder(term));
            }

            return builders;
        }

        public static BaseExpressionBuilder GetBulder(SearchTerm term)
        {
            BaseExpressionBuilder? builder;

            switch (term.Field.ToUpper())
            {
                //TODO : Remove the switch
                case SearchFieldsConstants.NAME:
                case SearchFieldsConstants.DESCRIPTION:
                case SearchFieldsConstants.TITLE:
                    return builder = CreateExpressionBuilder<TextExpressionBuilder>(term);

                    //TODO implement Quantity, Price as well
                default:
                    throw new NotImplementedException("FIELD_NOT_FOUND");
            }
        }
        public static TBaseExpresionBuilder CreateExpressionBuilder<TBaseExpresionBuilder>(SearchTerm searchTerm)
        {
            Type type = typeof(TBaseExpresionBuilder);
            var builder = type.GetConstructor(new Type[] { }).Invoke(new object[] { });

            type.GetProperty("FieldName").SetValue(
                builder, 
                searchTerm.Field.Substring(0, 1).ToUpper() + searchTerm.Field.Substring(1).ToLower());

            type.GetProperty("SearchTerm").SetValue(builder, searchTerm.Term);
            type.GetProperty("Comparator").SetValue(builder, searchTerm.Comparator);

            return (TBaseExpresionBuilder)builder;
        }
    }
}
