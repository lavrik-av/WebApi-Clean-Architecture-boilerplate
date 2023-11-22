namespace Eshop.WebApi.Definitions.UoW
{
    /// <summary>
    /// Register UnitOfWork as service
    /// </summary>
    public class UnitOfWorkDefinition : AppDefinition
    {
        public UnitOfWorkDefinition() { 
            OrderIndex = 2;
        }
        public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddUnitOfWork();
        }
    }
}
