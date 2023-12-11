using System.Linq.Expressions;

namespace Boilerplate.Application.Common.Filters.SearchHandlers.BooleanHandler
{
    public class BooleanSearchHandler : BaseSearchHandler
    {
        public bool SearchTerm { get; set; }
        protected override Expression BuildFilterExpression(Expression parameter)
        {
            //TODO: Implement the handler
            if (parameter is null)
            {
                return Expression.Empty();
            }
            else
            {
                // TODO: replace the text by Constant
                throw new NotImplementedException("Boolean type Search handler not implemented yet: namespace Boilerplate.Application.Common.Filters.SearchHandlers.BooleanHandler");
            }
        }
    }
}
