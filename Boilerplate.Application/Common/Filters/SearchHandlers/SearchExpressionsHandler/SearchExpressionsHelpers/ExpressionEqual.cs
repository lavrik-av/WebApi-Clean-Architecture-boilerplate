using System.Linq.Expressions;

namespace Boilerplate.Application.Common.Filters.SearchHandlers.SearchExpressionsHandler.SearchExpressionsHelpers
{
    internal class ExpressionEqual : ISearchExpressionKind
    {
        public Expression GetExpression(Expression parameter, string fieldName, object searchTerm, object? searchTermAux = null)
        {
            return Expression.Equal(
                Expression.Property(parameter, fieldName),
                Expression.Constant(searchTerm)
                );
        }
    }
}
