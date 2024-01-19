using System.Linq.Expressions;

namespace Boilerplate.Application.Common.Filters.SearchHandlers
{
    internal abstract class BaseSearchHandler
    {
        public string FieldName { get; set; } = string.Empty;

        public int Comparator { get; set; } = 0;

        protected abstract Expression BuildFilterExpression(Expression property);

        public abstract void SetHanlerSearchTerms(SearchTerm searchTerm);

        public IQueryable<T> ApplyFilterToQuery<T>(IQueryable<T> query)
        { 
            var parameter = Expression.Parameter(typeof(T), "p");
            Expression filterExpression = this.BuildFilterExpression(parameter);

            if (filterExpression == Expression.Empty()) 
            {
                return query;
            }
            else {
                var predicate = Expression.Lambda<Func<T, bool>>(filterExpression, parameter);
                return query.Where(predicate);
            }
        }
    }
}
