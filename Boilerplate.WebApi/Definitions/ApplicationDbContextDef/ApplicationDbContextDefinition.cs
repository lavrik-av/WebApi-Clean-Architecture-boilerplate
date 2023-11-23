namespace Boilerplate.WebApi.Definitions.ApplicationDbContextDef
{
    /// <summary>
    /// Register ApplicationDbContext and initilize DB Connection
    /// </summary>
    public class ApplicationDbContextDefinition : AppDefinition
    {
        
        public ApplicationDbContextDefinition() { 
            OrderIndex = 1;
            Enabled = false;
        }

        public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddApplicationDbContext(builder);
        }
    }
}
