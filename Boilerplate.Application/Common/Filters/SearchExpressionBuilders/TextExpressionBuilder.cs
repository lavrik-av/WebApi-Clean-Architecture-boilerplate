using System.Linq.Expressions;

public enum TextSearchComparator
{
    Equals = 1,
    NotEquals = 2,
    Contains = 3
}

namespace Boilerplate.Application.Common.Filters.SearchExpressionBuilders
{
    public class TextExpressionBuilder : BaseExpressionBuilder
    {
        public string SearchTerm { get; set; } = string.Empty;

        public TextSearchComparator Comparator { get; set; } = TextSearchComparator.Contains;

        public override Expression Build(Expression parameter)
        {

            if (SearchTerm == string.Empty) 
            {
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
