using Eshop.Application.Interfaces;
using Eshop.Persistence.Data;

namespace Eshop.WebApi.Definitions.UoW
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
