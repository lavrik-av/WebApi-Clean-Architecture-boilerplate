using Boilerplate.Application.Common;
using Boilerplate.Application.Common.Filters;
using Boilerplate.Application.Common.Filters.AuxParams;
using Microsoft.EntityFrameworkCore.Query;

namespace Boilerplate.Application.Interfaces.Repositories
{
    public interface IReadGenericRepository<TEntity>
        where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync(
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? Include = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? IncludeAux = null
            );
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<IList<TEntity>> Search(IList<SearchTerm> filters);
        Task<IList<TEntity>> SearchExt(AuxParams auxParams);
        Task<IList<TEntity>> GetAllPagedAsync(
            int PageIndex, 
            int PageSize, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> Include
            );  
        
    }
}
