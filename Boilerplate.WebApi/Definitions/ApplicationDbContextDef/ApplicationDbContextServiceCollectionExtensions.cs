using Boilerplate.Persistence.Data;
using Boilerplate.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.WebApi.Definitions.ApplicationDbContextDef
{
    public static class ApplicationDbContextServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                // Roll it back to just DefaultConnection after pushing it Github
                // options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionAzure"));
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            return services;
        }
    }
}
