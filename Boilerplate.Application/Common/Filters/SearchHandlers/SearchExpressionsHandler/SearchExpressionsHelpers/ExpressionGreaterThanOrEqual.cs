using System.Linq.Expressions;

namespace Boilerplate.Application.Common.Filters.SearchHandlers.SearchExpressionsHandler.SearchExpressionsHelpers
{
    public class ExpressionGreaterThanOrEqual : ISearchExpressionKind
    {
        public Expression GetExpression(Expression parameter, string fieldName, object searchTerm, object? searchTermAux = null)
        {
            return Expression.GreaterThanOrEqual(
                Expression.Property(parameter, fieldName),
                Expression.Constant(searchTerm)
                );
        }
    }
}
