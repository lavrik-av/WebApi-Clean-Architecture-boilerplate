using Boilerplate.Application.Common.Filters.AuxParams;
using Boilerplate.Application.Interfaces.Repositories;
using Boilerplate.Application.Interfaces.Repositories;

namespace Boilerplate.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEntitiesRepository EntitiesRepository { get; }
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IApplicationDbContext DbContext { get; }
    }
}
