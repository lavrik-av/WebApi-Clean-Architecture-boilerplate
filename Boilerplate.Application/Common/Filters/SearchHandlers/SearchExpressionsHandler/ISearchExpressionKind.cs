using System.Linq.Expressions;

namespace Boilerplate.Application.Common.Filters.SearchHandlers.SearchExpressionsHandler
{
    internal interface ISearchExpressionKind
    {
        public Expression GetExpression(Expression parameter, string fieldName, object searchTerm, object? searchTermAux = null);
    }
}
