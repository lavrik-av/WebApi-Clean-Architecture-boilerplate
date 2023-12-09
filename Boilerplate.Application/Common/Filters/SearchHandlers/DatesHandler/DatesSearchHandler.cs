using System.Linq.Expressions;
using Boilerplate.Application.Common.Filters.SearchHandlers.TextHandler;

namespace Boilerplate.Application.Common.Filters.SearchHandlers.DatesHandler
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
        public int Comparator { get; set; } = 1;

        private Dictionary<int, string> _comparator = DatesComparatorProvider.GetComparator();

        protected override Expression BuildFilterExpression(Expression parameter)
        {
            //TODO implement full functionality using all the cases: Equals, GreaterThanOrEqual and so on ...
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
