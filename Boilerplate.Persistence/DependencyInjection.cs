using Boilerplate.Application.Interfaces;
using Boilerplate.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                //local MS SQL Server
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

                Console.WriteLine($"=================================");
                Console.WriteLine($"=============== {configuration.GetConnectionString("DefaultConnection")} ==================");
                Console.WriteLine($"=================================");


                // local MySql server                
                // options.UseMySQL(configuration.GetConnectionString("MySqlConnection"));

                // Azure MS SQL Server
                // options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionAzure"));
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            return services;
        }
    }
}
