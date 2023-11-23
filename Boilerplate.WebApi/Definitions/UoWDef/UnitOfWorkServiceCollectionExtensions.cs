using Boilerplate.Application.Interfaces;
using Boilerplate.Persistence.Data;

namespace Boilerplate.WebApi.Definitions.UoW
{
    public static class UnitOfWorkServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
