using Boilerplate.Application.Common.Filters.SearchHandlers.SearchExpressionsHandler;
using System.Linq.Expressions;

namespace Boilerplate.Application.Common.Filters.SearchHandlers.DatesHandler
{
    internal class DatesSearchHandler : BaseSearchHandler
    {
        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public override void SetHanlerSearchTerms(SearchTerm searchTerm)
        {
            //TODO: It needs to set DateFrom to 00:00:00
            DateFrom =  DateTime.Parse(searchTerm.Term);

            //TODO: It needs to set DateTo to 23:59:59
            DateTo = DateTime.Parse(searchTerm.Term);

            if (searchTerm.TermAdd is not null)
            {
                //TODO: It needs to set DateTo to 23:59:59
                DateTo = DateTime.Parse(searchTerm.TermAdd);
            }
        }

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
