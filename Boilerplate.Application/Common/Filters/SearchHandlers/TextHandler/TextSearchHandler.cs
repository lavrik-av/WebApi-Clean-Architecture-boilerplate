using Boilerplate.Application.Common.Constants.Common;
using Boilerplate.Application.Common.Exceptions;
using System.Linq.Expressions;

namespace Boilerplate.Application.Common.Filters.SearchHandlers.TextHandler
{
    internal class TextSearchHandler : BaseSearchHandler
    {
        public string SearchTerm { get; set; } = string.Empty;

        public override void SetHanlerSearchTerms(SearchTerm searchTerm)
        {
            SearchTerm = searchTerm.Term;
        }

        private Dictionary<int, string> _comparator = TextComparatorProvider.GetComparator();

        protected override Expression BuildFilterExpression(Expression parameter)
        {

            if (SearchTerm == null)
            {
                return Expression.Empty();
            }
            else
            {
                if (!_comparator.ContainsKey(Comparator))
                {
                    throw new SearchException(CommonConstans.SEARCH_ERROR_PARAMS_COMPARATOR, CommonConstans.SEARCH_ERROR_WRONG_PARAMETERS_VALUE);
                }
                else
                {
                    return Expression.Call(
                            Expression.Property(parameter, FieldName),
                            typeof(string).GetMethod(_comparator[Comparator], new[] { typeof(string) }),
                            Expression.Constant(SearchTerm)
                        );

                }
            }
        }
    }

}
