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
        public TextComparator Comparator { get; set; } = TextComparator.Contains;

        protected override Expression BuildFilterExpression(Expression parameter)
        {

            if (this.SearchTerm == null) {
                return Expression.Empty();
            }
            else
            {
                return Expression.Call(
                        Expression.Property(parameter, FieldName),
                        typeof(string).GetMethod(this.Comparator.ToString(), new[] { typeof(string) }),
                        Expression.Constant(SearchTerm)
                    );
            }
        }
    }

}
