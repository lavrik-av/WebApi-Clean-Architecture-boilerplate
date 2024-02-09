using Autofac;
using AutoMapper;
using Boilerplate.Application.Interfaces;
using Boilerplate.Persistence.Data;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using MediatR.Extensions.Autofac.DependencyInjection;
using System.Reflection;
using Boilerplate.Application.EnititiesCommandsQueries.Enteties.Queries.GetProduct;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Boilerplate.Application.Common.Mappings;
using Autofac.Core;

namespace Boilerplate.UnitTests.Helpers
{
    internal static class DependencyInjection
    { 
        internal static ContainerBuilder RegisterServices()
        {
            var builder = new ContainerBuilder();

            RegisterDbContext(builder);
            RegisterUnitOfWork(builder);

            RegisterMapper(builder);
            RegisterAssemblyTypes(builder);

            return builder;
        }

        private static void RegisterDbContext(ContainerBuilder builder)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            configurationBuilder.AddJsonFile("appsettings.json");
            var config = configurationBuilder.Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            if (connectionString != null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer(connectionString);

                builder.RegisterType<ApplicationDbContext>()
                    .WithParameter(TypedParameter.From(optionsBuilder.Options))
                    .InstancePerLifetimeScope();
            }
            else
            {
                throw new NotFiniteNumberException("SQL Sever Connection string not found, check your appsetings.json file");
            }
        }

        private static void RegisterUnitOfWork(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }

        private static MapperConfiguration Test(Type mapperProfile)
        {
            return new MapperConfiguration(cfg => cfg.AddProfile(mapperProfile));
        }

        private static void RegisterMapper(ContainerBuilder builder)
        {
            Action<IMapperConfigurationExpression> configureMapper = (IMapperConfigurationExpression cfg) => {
                cfg.AddProfile<AutoMapperProfile>();
            };

            builder.RegisterType<MapperConfiguration>()
               .WithParameter(
                 new ResolvedParameter(
                   (pi, ctx) => pi.ParameterType == typeof(Action<IMapperConfigurationExpression>) && pi.Name == "configure",
                   (pi, ctx) => configureMapper));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();
        }

        private static void RegisterAssemblyTypes(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(GetEntityQueryHandler).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();
        }

        private static void RegisterMaps(ContainerBuilder builder, AutoMapperProfile profile)
        {
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();
        }

        public static IMediator BuildMediatr(ContainerBuilder builder)
        {
            var configuration = MediatRConfigurationBuilder
                .Create(typeof(GetEntityQuery).GetTypeInfo().Assembly)
                .WithAllOpenGenericHandlerTypesRegistered()
                .Build();

            return builder.RegisterMediatR(configuration).Build().Resolve<IMediator>();
        }
    }
}
