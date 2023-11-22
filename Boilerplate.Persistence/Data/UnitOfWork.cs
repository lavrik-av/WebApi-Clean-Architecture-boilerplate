using Eshop.Application.Common.Filters;
using Eshop.Application.Common.Filters.AuxParams;
using Eshop.Application.Interfaces;
using Eshop.Application.Interfaces.Repositories;
using Eshop.Domain.Enitities;
using Eshop.Domain.Enitities.ProductEnitties;
using Eshop.Persistence.Repositories;
using Microsoft.Identity.Client;

namespace Eshop.Persistence.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        protected Dictionary<Type, object> _repositories;

        public IProductsRepository ProductsRepository { get; private set; }

        public ICustomersRepository CustomersRepository { get; private set; }

        public IOrdersRepository OrdersRepository { get; private set; }

        public IOrderProductRepository OrderProductRepository { get; private set; }

        public IPostsRepository PostsRepository { get; private set; }

        public IApplicationDbContext DbContext { get; }

        public UnitOfWork(ApplicationDbContext applicationDbContext) 
        { 
            _context = applicationDbContext;

            DbContext = applicationDbContext;

            _repositories = new Dictionary<Type, object>();

            // TODO try to set all of them using a loop using Reflection

            ProductsRepository = new ProductsRepository(_context);
            _repositories.Add(ProductsRepository.RepositoryType, ProductsRepository);

            CustomersRepository = new CustomersRepository(_context);
            _repositories.Add(CustomersRepository.RepositoryType, CustomersRepository);

            OrdersRepository = new OrdersRepository(_context);
            _repositories.Add(OrdersRepository.RepositoryType, OrdersRepository);

            OrderProductRepository = new OrderProductRepository(_context);
            _repositories.Add(OrderProductRepository.RepositoryType, OrderProductRepository);

            PostsRepository = new PostsRepository(_context);
            _repositories.Add(PostsRepository.RepositoryType, PostsRepository);
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
