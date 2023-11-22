using Eshop.Application.Interfaces.Repositories;
using Eshop.Domain.Enitities;
using Eshop.Domain.Enitities.OrderEntities;
using Eshop.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Persistence.Repositories
{
    public class OrdersRepository : GenericRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
