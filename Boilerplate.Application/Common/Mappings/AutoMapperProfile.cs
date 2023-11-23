using AutoMapper;
using Boilerplate.Application.Dto.Entity;
using Boilerplate.Application.EnititiesCommandsQueries.Products.Commands.CreateProduct;
using Boilerplate.Application.EnititiesCommandsQueries.Products.Commands.UpdateProduct;
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
