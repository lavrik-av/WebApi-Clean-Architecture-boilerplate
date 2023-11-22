using Eshop.Application.Interfaces.Repositories;
using Eshop.Domain.Enitities.ProductEnitties;
using Eshop.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Persistence.Repositories
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        public ProductsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Guid> _UpdateAsync(Product entity, CancellationToken cancellationToken)
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
