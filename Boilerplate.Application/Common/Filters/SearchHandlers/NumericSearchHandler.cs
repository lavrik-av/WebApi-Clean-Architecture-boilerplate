using System.Linq.Expressions;

namespace Boilerplate.Application.Common.Filters.SearchHandlers
{
    public enum NumberComparator
    {
        Equal = 1,
        NotEqual = 2,
        GreaterThan = 3,
        GreaterThanOrEqual = 4,
        LessThan = 5,
        LessThanOrEqual = 6
    }
    public class NumericSearchHandler : BaseSearchHandler
    {
        public decimal? SearchTerm { get; set; } = 0;

        public NumberComparator Comparator { get; set; } = NumberComparator.Equal;
        protected override Expression BuildFilterExpression(Expression parameter)
        {
            if (SearchTerm == null)
            {
                return Expression.Empty();
            }
            else
            {
                return GetExpression(parameter);
            }
        }

        protected Expression GetExpression(Expression parameter)
        {
            switch (Comparator)
            {
                case NumberComparator.Equal:
                    return Expression.Equal(Expression.Property(parameter, FieldName), Expression.Constant(SearchTerm));

                case NumberComparator.NotEqual:
                    return Expression.NotEqual(Expression.Property(parameter, FieldName), Expression.Constant(SearchTerm));

                case NumberComparator.GreaterThan:
                    return Expression.GreaterThan(Expression.Property(parameter, FieldName), Expression.Constant(SearchTerm));

                case NumberComparator.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(Expression.Property(parameter, FieldName), Expression.Constant(SearchTerm));

                case NumberComparator.LessThan:
                    return Expression.LessThan(Expression.Property(parameter, FieldName), Expression.Constant(SearchTerm));

                case NumberComparator.LessThanOrEqual:
                    return Expression.LessThanOrEqual(Expression.Property(parameter, FieldName), Expression.Constant(SearchTerm));

                default:
                    throw new NotImplementedException("Comparator not supported");
            }
        }

    }
}
