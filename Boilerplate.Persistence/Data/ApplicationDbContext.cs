using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Eshop.Application.Interfaces;
using Eshop.Domain.Enitities.ProductEnitties;
using Eshop.Domain.Enitities.CusomerEntities;
using Eshop.Domain.Enitities.OrderEntities;
using Eshop.Persistence.EntitiyTypeConfigurations;
using Eshop.Domain.Enitities.PostEntities;
using Eshop.Domain.Enitities.TagEnities;
using Eshop.Application.EnititiesCommandsQueries.ComplexQuery.Queries;
using Microsoft.Identity.Client;
using Eshop.Domain.Enitities.ActorsEntities;

namespace Eshop.Persistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>, IApplicationDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrdersProducts> OrdersProducts { get; set; }        
        
        /*  These ones are views not tables */
        public DbSet<ComplexQueryModel> OrdersProductsCustomersGrouped { get; set; }
        public DbSet<CustomerOrdersProducts> CustomersOrdersProducts { get; set; }
        public DbSet<CustomersOrdersProductsTotals> CustomersOrdersProductsTotals { get; set; }

        //Sakila tables
        public DbSet<Actor> Actors { get; set; }

        public DbSet<ProductMedia> ProductMedia { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, bool designTime = false) : base(options)
        {
            if (!designTime)
            {
                Database.EnsureCreated();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());

            builder.Entity<Actor>().HasNoKey();

            // Do I need it?
            // builder.Entity<Post>().Navigation(post => post.Tag).AutoInclude();

            base.OnModelCreating(builder);
        }

    }

}
