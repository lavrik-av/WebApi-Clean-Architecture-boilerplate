using Boilerplate.Application.Common.Filters.SearchHandlers.SearchExpressionsHandler;
using System.Linq.Expressions;

namespace Boilerplate.Application.Common.Filters.SearchHandlers.DatesHandler
{
    public class DatesSearchHandler : BaseSearchHandler
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }

        protected override Expression BuildFilterExpression(Expression parameter)
        {

            if (parameter is null)
            {
                return Expression.Empty();
            }
            else
            {
                if (ExpressionsHandler.Expressions.ContainsKey(Comparator))
                {
                    return ExpressionsHandler.Expressions[Comparator].GetExpression(parameter, FieldName, DateFrom, DateTo);
                }

                // TODO: replace the text by Constant
                throw new NotImplementedException($"Wrong Comparator value: {Comparator}, should be an integer value from 1 to 7");
            }
        }
    }
}
