using Eshop.Domain.Enitities.OrderEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eshop.Persistence.EntitiyTypeConfigurations
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrdersProducts>
    {
        public void Configure(EntityTypeBuilder<OrdersProducts> builder)
        {
        }
    }
}
