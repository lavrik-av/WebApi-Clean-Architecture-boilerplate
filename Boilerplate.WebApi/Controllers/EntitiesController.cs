using Microsoft.AspNetCore.Mvc;
using MediatR;
using Autofac;
using Boilerplate.Application.Dto.Entity;
using Boilerplate.Application.Common;
using Boilerplate.Application.EnititiesCommandsQueries.Enteties.Queries.GetEntities;
using Boilerplate.Application.Interfaces;
using Boilerplate.Application.EnititiesCommandsQueries.Enteties.Commands.CreateEntity;
using Boilerplate.Application.EnititiesCommandsQueries.Enteties.Commands.UpdateEntity;
using Boilerplate.Application.EnititiesCommandsQueries.Enteties.Queries.SearchEntity;

namespace Boilerplate.WebApi.Controllers
{
    [ApiController]
    [Route("api/entities")]
    public class EntitiesController : ControllerBase
    {

        private readonly ISender _sender;
        private readonly IGenericTypeMediator _genericTypeMediator;

        public EntitiesController(ISender sender, IGenericTypeMediator genericTypeMediator)
        {
            _sender = sender;
            _genericTypeMediator = genericTypeMediator;
        }

        [HttpGet]
        public async Task<OperationResult<IList<EntityDto>>> GetEntities()
        {
            return await _sender.Send(new GetEntitiesQuery());
        }

        //[HttpPost("get-paged-list")]
        //public async Task<OperationResultList<IList<EntityDto>>> GetProductsPaged(GetProductsPagedModel model ) 
        //{
        //    return await _sender.Send(new GetProductsPagedQuery(model));
        //}

        //[HttpGet(":id")]
        //public async Task<OperationResult<EntityDto>> GetProductDetails([FromQuery] GetProductModel product)
        //{
        //    return await _sender.Send(new GetProductQuery(new GetProductModel() { Id = product.Id }));
        //}

        [HttpPut()]
        public async Task<OperationResult<EntityDto>> UpdateAsync([FromBody] UpdateEntityModel entity)
        {
            return await _sender.Send(new UpdateEntityCommand(entity));
        }


        [HttpPost]
        public async Task<OperationResult<EntityDto>> AddAsync([FromBody] CreateEntityModel entity)
        {
            return await _sender.Send(new CreateEntityCommand(entity));
        }

        [HttpPost("search")]
        public async Task<OperationResult<IList<EntityDto>>> SearchEntity([FromBody] SearchFilterModel filterModel)
        {
            return await _sender.Send(new SearchEntityQuery(filterModel));
        }

        //TODO add GetAllPagedAsync(GenericRepository) endpoint

        //[HttpPost("serch-ext")]
        //public async Task<PagedList<EntityDto>> SearchExt([FromBody] AuxParams auxParams)
        //{
        //    return await _genericTypeMediator.Sender.Send(new SearchEntitiesParametersQuery<Product, EntityDto>(auxParams));
        //}

        //[HttpDelete("delete")]
        //public async Task<OperationResult<EmptyResult>> DeleteAsync([FromBody] DeleteEntityModel product)
        //{
        //    return await _sender.Send(new DeleteEntityCommand(product) );
        //}

    }
}
