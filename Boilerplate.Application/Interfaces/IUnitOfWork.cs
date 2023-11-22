using Boilerplate.Application.Common.Filters.AuxParams;
using Boilerplate.Application.Interfaces.Repositories;
using Eshop.Application.Interfaces.Repositories;

namespace Boilerplate.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEntityRepository EntitiesRepository { get; }
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IApplicationDbContext DbContext { get; }
    }
}
