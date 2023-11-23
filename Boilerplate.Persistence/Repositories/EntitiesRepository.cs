using Boilerplate.Domain.Enitities.Entity;
using Boilerplate.Application.Interfaces.Repositories;
using Boilerplate.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Persistence.Repositories
{
    public class EntitiesRepository : GenericRepository<Entity>, IEntitiesRepository
    {
        public EntitiesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Guid> _UpdateAsync(Entity entity, CancellationToken cancellationToken)
        {
            var product = await _dBSet.FirstOrDefaultAsync(product => product.Id == entity.Id, cancellationToken);

            if (product == null) {
                return Guid.Empty;
            }

            product.Id = entity.Id;
            product.Name = entity.Name;
            product.Description = entity.Description;
            product.Sku = entity.Sku;
            product.Price = entity.Price;
               
            return product.Id;
        }

    }
}
