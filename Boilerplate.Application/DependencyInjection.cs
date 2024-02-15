using Boilerplate.Application.Common.Behavior;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace Boilerplate.Application
{
    public static class DependencyInjection
    {
        public static void ConfigureApplication(this IServiceCollection services) 
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        }
    }
}
