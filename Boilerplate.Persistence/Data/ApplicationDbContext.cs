using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Boilerplate.Application.Interfaces;
using Boilerplate.Persistence.EntitiyTypeConfigurations;
using Boilerplate.Domain.Enitities.Entity;

namespace Boilerplate.Persistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>, IApplicationDbContext
    {
        public DbSet<Entity> Entities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, bool designTime = false) : base(options)
        {
            if (!designTime)
            {
                Database.EnsureCreated();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EntityConfiguration());
            base.OnModelCreating(builder);
        }

    }

}
