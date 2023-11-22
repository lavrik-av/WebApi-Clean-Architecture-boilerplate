using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace Boilerplate.Application.Common.Filters.SearchHandlers
{
    public enum IntegerComparator
    {
        Equal = 1,
        NotEqual = 2,
        GreaterThan = 3,
        LessThan = 4,
        Between = 5
    }
    public class IntegerSearchHandler : BaseSearchHandler
    {
        public int SearchTerm { get; set; } = 0;
        public IntegerComparator Comparator { get; set; } = IntegerComparator.Equal;
        protected override Expression BuildFilterExpression(Expression parameter)
        {
            if (parameter == null) 
            {
                return Expression.Empty();
            }
            else
            {
                return GetExpression(parameter);
            }
        }

        private Expression GetExpression(Expression parameter)
        {
            switch (Comparator) {
                case IntegerComparator.Equal:
                    return Expression.Equal(
                        Expression.Property(parameter, FieldName),
                        Expression.Constant(SearchTerm)
                        );

                case IntegerComparator.NotEqual:
                    return Expression.NotEqual(
                        Expression.Property(parameter, FieldName),
                        Expression.Constant(SearchTerm)
                        );

                case IntegerComparator.GreaterThan:
                    return Expression.GreaterThan(
                        Expression.Property(parameter, FieldName),
                        Expression.Constant(SearchTerm)
                        );

                case IntegerComparator.LessThan:
                    return Expression.LessThan(
                        Expression.Property(parameter, FieldName),
                        Expression.Constant(SearchTerm)
                        );

                case IntegerComparator.Between:

                    var gt = Expression.GreaterThanOrEqual(
                            Expression.Property(parameter, FieldName), Expression.Constant(SearchTerm)
                        );

                    var lt = Expression.LessThanOrEqual(
                            Expression.Property(parameter, FieldName), Expression.Constant(SearchTerm)
                        );

                    return Expression.And(gt, lt);
            }

            throw new NotImplementedException($"{Comparator}: Comparator not implemented");
        }

    }
}
