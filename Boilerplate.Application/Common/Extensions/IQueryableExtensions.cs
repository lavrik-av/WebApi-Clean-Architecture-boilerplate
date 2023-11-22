using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Boilerplate.Application.Common.Extensions
{
    public static class IQueryableExtensions
    {
        public static void ToOperationListResult<TEntity>(
            IQueryable<TEntity> query,
            IList<TEntity> items,
            int PageIndex,
            int PageSize
        )
        {
        }
        public static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> query, string fieldName, bool ascending = true )
        {
            var parameter = Expression.Parameter( typeof(TEntity), "p" );
            var member = Expression.Property(parameter, fieldName);
            var lambda = Expression.Lambda(member, parameter);

            var body = Expression.Call(
                typeof(Queryable),
                ascending ? "OrderBy" : "OrderByDescending",
                new[] {typeof(TEntity), typeof(TEntity).GetProperty(fieldName).PropertyType},
                query.Expression,
                Expression.Quote(lambda)
                );

            return (IOrderedQueryable<TEntity>) query.Provider.CreateQuery<TEntity>(body);
        }
        public static IIncludableQueryable<TEntity, object> IncludeExt<TEntity>(this IQueryable<TEntity> query, string navigationField )
        {

            var propertyInfo = typeof(TEntity).GetProperty(navigationField);
            var parameter = Expression.Parameter(typeof(TEntity), "p");
            var member = Expression.Property(parameter, navigationField);
            var lambda = Expression.Lambda(member, parameter);

            Expression body;

            try
            {
                body = Expression.Call(
                    typeof(Queryable),
                    "Include",
                    new[] { propertyInfo.PropertyType },
                    query.Expression,
                    Expression.Quote(lambda)
                    );
            }
            catch (Exception e)
            {
                throw new NotImplementedException(e.Message);
            }

            return (IIncludableQueryable<TEntity, object>) query.Provider.CreateQuery<TEntity>(body);
        }

        public static IQueryable GetFilteredQueryableList(this IQueryable target, string propertyName, string searchValues)
        {
            //Get target's T 
            var targetType = target.GetType().GetGenericArguments().FirstOrDefault();
            if (targetType == null)
                throw new ArgumentException("Should be IEnumerable<T>", "target");

            //Get searchValues's T
            var searchValuesType = searchValues.GetType().GetGenericArguments().FirstOrDefault();
            if (searchValuesType == null)
                throw new ArgumentException("Should be IEnumerable<T>", "searchValues");

            //Create a p parameter with the type T of the items in the -> target IEnumerable<T>
            var containsLambdaParameter = Expression.Parameter(targetType, "p");

            //Create a property accessor using the property name -> p.#propertyName#
            var property = Expression.Property(containsLambdaParameter, targetType, propertyName);

            //Create a constant with the -> IEnumerable<T> searchValues
            var searchValuesAsConstant = Expression.Constant(searchValues, searchValues.GetType());

            //Create a method call -> searchValues.Contains(p.Id)
            var containsBody = Expression.Call(typeof(Queryable), "Contains", new[] { searchValuesType }, searchValuesAsConstant, property);

            //Create a lambda expression with the parameter p -> p => searchValues.Contains(p.Id)
            var containsLambda = Expression.Lambda(containsBody, containsLambdaParameter);

            //Create a constant with the -> IEnumerable<T> target
            var targetAsConstant = Expression.Constant(target, target.GetType());

            //Where(p => searchValues.Contains(p.Id))
            var whereBody = Expression.Call(typeof(Queryable), "Where", new[] { targetType }, targetAsConstant, containsLambda);

            //target.Where(p => searchValues.Contains(p.Id))
            var whereLambda = Expression.Lambda<Func<IQueryable>>(whereBody).Compile();

            return whereLambda.Invoke();
        }

    }
}
