using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Eshop.WebApi.Interfaces
{
    internal interface IAppDefinition
    {
        int OrderIndex { get; protected set; }
        bool Enabled { get; protected set; }
        void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder);
        void ConfigureApplication(WebApplication app);
    }
}
