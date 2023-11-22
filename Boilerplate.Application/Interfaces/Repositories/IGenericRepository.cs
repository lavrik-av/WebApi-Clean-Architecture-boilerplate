using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> : IReadGenericRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetDbSet();
        DbSet<TEntity> GetDbSetForRawSql();
        IApplicationDbContext GetDbContext();
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task<Guid> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Type RepositoryType { get; }
    }
}
