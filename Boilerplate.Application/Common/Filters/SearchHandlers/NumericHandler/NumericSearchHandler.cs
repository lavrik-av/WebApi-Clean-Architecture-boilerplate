using System.Linq.Expressions;
using Boilerplate.Application.Common.Filters.SearchHandlers.SearchExpressionsHandler;

namespace Boilerplate.Application.Common.Filters.SearchHandlers.NumericHandler
{
    public class NumericSearchHandler : BaseSearchHandler
    {
        public decimal? SearchTerm { get; set; }

        protected override Expression BuildFilterExpression(Expression parameter)
        {
            if (SearchTerm is null)
            {
                return Expression.Empty();
            }
            else
            {
                if (ExpressionsHandler.Expressions.ContainsKey(Comparator))
                {
                    return ExpressionsHandler.Expressions[Comparator].GetExpression(parameter, FieldName, SearchTerm);
                }

                // TODO: replace the text by Constant
                throw new NotImplementedException($"Wrong Comparator value: {Comparator}, should be an integer value from 1 to 7");
            }
        }
    }
}
