using Boilerplate.Application.Common.Constants.Common;
using Boilerplate.Application.Common.Filters.SearchHandlers.SearchExpressionsHandler.SearchExpressionsHelpers;

namespace Boilerplate.Application.Common.Filters.SearchHandlers.SearchExpressionsHandler
{
    internal static class ExpressionsHandler
    {
        public static Dictionary<int, ISearchExpressionKind> Expressions { get; } = new Dictionary<int, ISearchExpressionKind>() {
            { ExpressionsFunctionsConstants.Equal, new ExpressionEqual() },
            { ExpressionsFunctionsConstants.NotEqual, new ExpressionNotEqual() },
            { ExpressionsFunctionsConstants.GreaterThan, new ExpressionGreaterThan() },
            { ExpressionsFunctionsConstants.GreaterThanOrEqual, new ExpressionGreaterThanOrEqual() },
            { ExpressionsFunctionsConstants.LessThanOrEqual, new ExpressionLessThanOrEqual() },
            { ExpressionsFunctionsConstants.LessThan, new ExpressionLessThan() },
            { ExpressionsFunctionsConstants.Between, new ExpressionBetween() }
        };
    }
}
