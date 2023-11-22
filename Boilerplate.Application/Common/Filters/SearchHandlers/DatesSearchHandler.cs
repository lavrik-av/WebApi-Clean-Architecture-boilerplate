using System.Linq.Expressions;

namespace Boilerplate.Application.Common.Filters.SearchHandlers
{

    public enum DatesComparator
    {
        Equals = 1,
        NotEqual = 2,
        GreaterThan = 3,
        GreaterThanOrEqual = 4,
        LessThan = 5,
        LessThanOrEqual = 6
    }
    public class DatesSearchHandler : BaseSearchHandler
    {

        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        public TextComparator Comparator { get; set; } = TextComparator.Contains;

        protected override Expression BuildFilterExpression(Expression parameter)
        {
            var olderThanExpr = Expression.GreaterThan(
                    Expression.Property(parameter, FieldName), 
                    Expression.Constant(DateFrom)
                );
            var newerThanExpr = Expression.LessThan(
                    Expression.Property(parameter, FieldName), 
                    Expression.Constant(DateTo)
                );

            return Expression.And(olderThanExpr, newerThanExpr);
        }
    }
}
