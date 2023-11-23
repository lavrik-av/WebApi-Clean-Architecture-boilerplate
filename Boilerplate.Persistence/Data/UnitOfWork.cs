using Boilerplate.Application.Interfaces;
using Boilerplate.Application.Interfaces.Repositories;
using Boilerplate.Persistence.Repositories;

namespace Boilerplate.Persistence.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        protected Dictionary<Type, object> _repositories;
        public IEntitiesRepository EntitiesRepository { get; private set; }

        public IApplicationDbContext DbContext { get; }

        public UnitOfWork(ApplicationDbContext applicationDbContext) 
        { 
            _context = applicationDbContext;

            DbContext = applicationDbContext;

            _repositories = new Dictionary<Type, object>();

            EntitiesRepository = new EntitiesRepository(_context);
            _repositories.Add(EntitiesRepository.RepositoryType, EntitiesRepository);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            _repositories ??= new Dictionary<Type, object>();

            if (!_repositories.ContainsKey(typeof(TEntity)))
            {
                _repositories.Add(typeof(TEntity), new GenericRepository<TEntity>(_context));
            }

            return (IGenericRepository<TEntity>)_repositories[typeof(TEntity)];
        }
    }
}
