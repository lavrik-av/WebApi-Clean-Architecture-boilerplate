using Eshop.Application.Interfaces.Repositories;
using Eshop.Domain.Enitities.OrderEntities;
using Eshop.Persistence.Data;

namespace Eshop.Persistence.Repositories
{
    public class OrderProductRepository : GenericRepository<OrdersProducts>, IOrderProductRepository
    {
        public OrderProductRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<OrdersProducts> AddOrderProductAsync(OrdersProducts entity, CancellationToken cancellationToken)
        {
            var newEntity = await _dBSet.AddAsync(entity, cancellationToken);
            return newEntity.Entity;
        }
    }
}
