using AutoMapper;
using Boilerplate.Application.Dto.Entity;
using Boilerplate.Application.EnititiesCommandsQueries.Enteties.Commands.CreateEntity;
using Boilerplate.Application.EnititiesCommandsQueries.Enteties.Commands.UpdateEntity;
using Boilerplate.Domain.Enitities.Entity;

namespace Boilerplate.Application.Common.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Entity, EntityDto>();
            CreateMap<UpdateEntityModel, EntityDto>();
            CreateMap<CreateEntityModel, Entity>();
            CreateMap<UpdateEntityModel, Entity>();
            CreateMap<EntityMedia, EntityMediaDto>();
        }
    }
}
