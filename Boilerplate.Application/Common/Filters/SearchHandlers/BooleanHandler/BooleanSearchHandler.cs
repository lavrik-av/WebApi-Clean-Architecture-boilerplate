using System.Linq.Expressions;

namespace Boilerplate.Application.Common.Filters.SearchHandlers.BooleanHandler
{
    internal class BooleanSearchHandler : BaseSearchHandler
    {
        public bool SearchTerm { get; set; }

        public override void SetHanlerSearchTerms(SearchTerm searchTerm)
        {
            //TODO: Implement the method
        }
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
