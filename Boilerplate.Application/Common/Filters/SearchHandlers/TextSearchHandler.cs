using Boilerplate.Application.Common.Constants.Common;
using Boilerplate.Application.Common.Exceptions;
using System.Linq.Expressions;

namespace Boilerplate.Application.Common.Filters.SearchHandlers
{
    public enum TextComparator
    {
        Equals = 1,
        NotEqual = 2,
        Contains = 3
    }

    public class TextSearchHandler : BaseSearchHandler
    {
        public string SearchTerm { get; set; } = string.Empty;
        public int Comparator { get; set; } = 1;

        private Dictionary<int, string> _innerComparator = new Dictionary<int, string>() { {1, "Equals" }, { 2, "NotEqual" }, { 3, "Contains" } };

        protected override Expression BuildFilterExpression(Expression parameter)
        {

            if (this.SearchTerm == null) {
                return Expression.Empty();
            }
            else
            {
                if (!_innerComparator.ContainsKey(this.Comparator))
                {
                    throw new SearchException(CommonConstans.SEARCH_ERROR_PARAMS_COMPARATOR, CommonConstans.SEARCH_ERROR_WRONG_PARAMETERS_VALUE);
                }
                else
                {
                    return Expression.Call(
                            Expression.Property(parameter, FieldName),
                            typeof(string).GetMethod(_innerComparator[this.Comparator], new[] { typeof(string) }),
                            Expression.Constant(SearchTerm)
                        );

                }
            }
        }
    }

}
