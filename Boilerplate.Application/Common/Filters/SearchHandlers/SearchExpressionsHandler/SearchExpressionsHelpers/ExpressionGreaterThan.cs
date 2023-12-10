using System.Linq.Expressions;

namespace Boilerplate.Application.Common.Filters.SearchHandlers.SearchExpressionsHandler.SearchExpressionsHelpers
{
    public class ExpressionGreaterThan : ISearchExpressionKind
    {
        public Expression GetExpression(Expression parameter, string fieldName, object searchTerm, object? searchTermAux = null)
        {
            return Expression.GreaterThan(
                Expression.Property(parameter, fieldName),
                Expression.Constant(searchTerm)
                );
        }
    }
}
