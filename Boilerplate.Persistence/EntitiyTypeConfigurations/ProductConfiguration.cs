using Eshop.Domain.Enitities.ProductEnitties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eshop.Persistence.EntitiyTypeConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(product => product.Name).IsUnique();
            builder.HasIndex(product => product.Sku).IsUnique();
        }
    }
}
