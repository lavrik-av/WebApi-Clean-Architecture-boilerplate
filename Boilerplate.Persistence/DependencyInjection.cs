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

                var connectionString = configuration.GetConnectionString("DefaultConnection");

                if (Environment.GetEnvironmentVariable("DOCKER_COMPOSE_MODE") is not null && 
                    Environment.GetEnvironmentVariable("DOCKER_COMPOSE_MODE") == "Y")
                {
                    connectionString = configuration.GetConnectionString("DefaultConnectionDocker");
                }
                else if (Environment.GetEnvironmentVariable("DOCKER_MODE") is not null &&
                    Environment.GetEnvironmentVariable("DOCKER_MODE") == "Y")
                {
                    throw new NotImplementedException("The app should be run with Docker Compose only as it uses other relaited services within a Docker container");
                }

                options.UseSqlServer(connectionString);

                Console.WriteLine($"============== SQL Server Connection string ===================");
                Console.WriteLine($"=============== {connectionString} ==================");
                Console.WriteLine($"=================================");
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            return services;
        }
    }
}
