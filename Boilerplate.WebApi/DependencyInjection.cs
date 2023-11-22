﻿using Eshop.Application.Interfaces;
using Eshop.WebApi.GenericTypeMediatR;

namespace Eshop.WebApi
{
    public static class DependencyInjection
    {
        public static void ConfigureWebApi(this IServiceCollection services, string allowSpecificOrigins)
        {
            services.AddAutoMapper(typeof(IApplicationDbContext));
            services.AddScoped<IGenericTypeMediator, GenericTypeMediator>();

            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: allowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200", "http://localhost:4300");
                    });
            });


        }
    }
}
