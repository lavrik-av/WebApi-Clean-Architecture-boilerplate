using AutoMapper;
using Boilerplate.Application.Dto.Entity;
using Boilerplate.Domain.Enitities.Entity;

namespace Boilerplate.Application.Common.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Entity, EntityDto>();
            CreateMap<EntityMedia, EntityMediaDto>();
        }
    }
}
