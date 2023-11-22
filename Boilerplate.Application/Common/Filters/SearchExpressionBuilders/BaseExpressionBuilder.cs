using System.Linq;
using System.Linq.Expressions;

namespace Boilerplate.Application.Common.Filters.SearchExpressionBuilders
{
    public abstract class BaseExpressionBuilder
    {
        public string FieldName { get; set; } = string.Empty;
        public IQueryable<T> ApplyFilterToQuery<T>(IQueryable<T> query)
        {
            var parameter = Expression.Parameter(typeof(T), "p");
            Expression filterExpression = this.Build(parameter);

            if (filterExpression == Expression.Empty()) 
            { 
                return query;
            } 
            else 
            {
                var predicate = Expression.Lambda<Func<T, bool>>(filterExpression, parameter);
                return query.Where(predicate);
            }
        }

        public abstract Expression Build(Expression parameter);
    }
}
