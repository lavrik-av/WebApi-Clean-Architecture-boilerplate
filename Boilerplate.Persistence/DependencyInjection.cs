using Eshop.Application.Interfaces;
using Eshop.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                //localhost DB
                // options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

                // Connect with MySql server                
                 options.UseMySQL(configuration.GetConnectionString("MySqlConnection"));

                // Azure DB
                // options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionAzure"));
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            return services;
        }
    }
}
