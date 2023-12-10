using System.Linq.Expressions;

namespace Boilerplate.Application.Common.Filters.SearchHandlers.SearchExpressionsHandler.SearchExpressionsHelpers
{
    public class ExpressionBetween : ISearchExpressionKind
    {
        private Expression PrepareGtExpression(Expression parameter, string fieldName, object searchTerm)
        {
            return Expression.GreaterThanOrEqual(
                Expression.Property(parameter, fieldName),
                Expression.Constant(searchTerm)
                );
        }
        private Expression PrepareLtExpression(Expression parameter, string fieldName, object searchTerm)
        {
            return Expression.LessThanOrEqual(
                Expression.Property(parameter, fieldName),
                Expression.Constant(searchTerm)
                );
        }

        public Expression GetExpression(Expression parameter, string fieldName, object searchTerm, object? searchTermAux)
        {

            Expression gt = PrepareGtExpression(parameter, fieldName, searchTerm);
            Expression lt = PrepareLtExpression(parameter, fieldName, searchTerm);

            if (searchTermAux is not null)
            {
                lt = PrepareLtExpression(parameter, fieldName, searchTermAux);
            }

            return Expression.AndAlso(gt, lt);
        }
    }
}
