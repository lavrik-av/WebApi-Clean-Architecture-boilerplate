using System.Linq.Expressions;

namespace Boilerplate.Application.Common.Filters.SearchHandlers.SearchExpressions
{
    public static class ExpressionsFunctionsConstants
    {
        public const int Equal = 1;
        public const int NotEqual = 2;
        public const int GreaterThan = 3;
        public const int GreaterThanOrEqual = 4;
        public const int LessThanOrEqual = 5;
        public const int LessThan = 6;
        public const int Between = 7;
    }

    public interface ISearchExpressionKind
    {
        public Expression GetExpression(Expression parameter, int SearchTerm, string FieldName);
    }

    public class ExpressionEqual : ISearchExpressionKind
    {
        public Expression GetExpression(Expression parameter, int SearchTerm, string FieldName)
        {
            return Expression.Equal(
                Expression.Property(parameter, FieldName),
                Expression.Constant(SearchTerm)
                );
        }
    }

    public class ExpressionNotEqual : ISearchExpressionKind
    {
        public Expression GetExpression(Expression parameter, int SearchTerm, string FieldName)
        {
            return Expression.NotEqual(
                Expression.Property(parameter, FieldName),
                Expression.Constant(SearchTerm)
                );
        }
    }

    public class ExpressionGreaterThan : ISearchExpressionKind
    {
        public Expression GetExpression(Expression parameter, int SearchTerm, string FieldName)
        {
            return Expression.GreaterThan(
                Expression.Property(parameter, FieldName),
                Expression.Constant(SearchTerm)
                );
        }
    }

    public class ExpressionGreaterThanOrEqual : ISearchExpressionKind
    {
        public Expression GetExpression(Expression parameter, int SearchTerm, string FieldName)
        {
            return Expression.GreaterThanOrEqual(
                Expression.Property(parameter, FieldName),
                Expression.Constant(SearchTerm)
                );
        }
    }

    public class ExpressionLessThanOrEqual : ISearchExpressionKind
    {
        public Expression GetExpression(Expression parameter, int SearchTerm, string FieldName)
        {
            return Expression.LessThanOrEqual(
                Expression.Property(parameter, FieldName),
                Expression.Constant(SearchTerm)
                );
        }
    }

    public class ExpressionLessThan : ISearchExpressionKind
    {
        public Expression GetExpression(Expression parameter, int SearchTerm, string FieldName)
        {
            return Expression.LessThan(
                Expression.Property(parameter, FieldName),
                Expression.Constant(SearchTerm)
                );
        }
    }

    public class ExpressionBetween : ISearchExpressionKind
    {
        public Expression GetExpression(Expression parameter, int SearchTerm, string FieldName)
        {
            var gt = Expression.GreaterThanOrEqual(
                    Expression.Property(parameter, FieldName), Expression.Constant(SearchTerm)
                );

            var lt = Expression.LessThanOrEqual(
                    Expression.Property(parameter, FieldName), Expression.Constant(SearchTerm)
                );

            return Expression.And(gt, lt);
        }
    }

    public static class ExpressionsHandler
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
