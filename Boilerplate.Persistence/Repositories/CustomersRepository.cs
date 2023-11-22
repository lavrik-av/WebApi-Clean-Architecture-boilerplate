using Eshop.Application.Interfaces.Repositories;
using Eshop.Domain.Enitities.CusomerEntities;
using Eshop.Domain.Enitities.OrderEntities;
using Eshop.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Persistence.Repositories
{
    public class CustomersRepository : GenericRepository<Customer>, ICustomersRepository
    {
        public CustomersRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IList<Customer>> GetAllCustomersAsync()
        {
            return await _dBSet
                .Select(customer => customer)
                .Include(customer => customer.Orders)
                .ToListAsync();
        }
    }
}
