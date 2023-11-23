using Boilerplate.WebApi.Interfaces;

namespace Boilerplate.WebApi.Definitions
{
    public abstract class AppDefinition : IAppDefinition
    {
        public virtual int OrderIndex { get; set; } = 0;

        public virtual bool Enabled { get; set; } = true;

        public virtual void ConfigureApplication(WebApplication app)
        {
        }

        public virtual void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
        {
        }
    }
}
