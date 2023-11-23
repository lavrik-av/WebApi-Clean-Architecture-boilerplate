using Autofac;
using Boilerplate.Application.Interfaces;
using Boilerplate.Application.EnititiesCommandsQueries.Search.Queries.SearchEntitiesParameters;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using MediatR.Extensions.Autofac.DependencyInjection;
using System.Reflection;
using MediatR;
using Boilerplate.Domain.Enitities;
using AutoMapper;

namespace Boilerplate.WebApi.GenericTypeMediatR
{
    public class GenericTypeMediator : IGenericTypeMediator
    {
        public GenericTypeMediator(
            IUnitOfWork unitOfWork,
            IMapper mapper
            ) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            var builder = new ContainerBuilder();

            var configuration = MediatRConfigurationBuilder
                .Create(Assembly.GetExecutingAssembly())
                .WithAllOpenGenericHandlerTypesRegistered()
                .Build();

            builder.RegisterMediatR(configuration);

            IList<Autofac.Core.Parameter> parameters = new List<Autofac.Core.Parameter>
            {
                new TypedParameter(typeof(IUnitOfWork), _unitOfWork),
                new TypedParameter(typeof(IMapper), _mapper)
            };

            builder
                .RegisterGeneric(typeof(SearchEntitiesParametersQueryHandler<,>))
                .AsImplementedInterfaces()
                .WithParameters(parameters);

            _sender = builder.Build().Resolve<IMediator>();
        }
    }
}
