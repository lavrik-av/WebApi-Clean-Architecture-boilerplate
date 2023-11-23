using Boilerplate.Domain.Enitities.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boilerplate.Persistence.EntitiyTypeConfigurations
{
    public class EntityConfiguration : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.HasIndex(entity => entity.Name).IsUnique();
            builder.HasIndex(entity => entity.Sku).IsUnique();
        }
    }
}
