using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Boilerplate.WebApi.Interfaces
{
    internal interface IAppDefinition
    {
        int OrderIndex { get; protected set; }
        bool Enabled { get; protected set; }
        void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder);
        void ConfigureApplication(WebApplication app);
    }
}
