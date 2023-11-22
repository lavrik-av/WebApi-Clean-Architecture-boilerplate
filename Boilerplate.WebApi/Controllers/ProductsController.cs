using Microsoft.AspNetCore.Mvc;
using MediatR;
using Autofac;
using Eshop.Application.EnititiesCommandsQueries.Products.Queries.GetProducts;
using Eshop.Application.Dto.Product;
using Eshop.Application.EnititiesCommandsQueries.Products.Commands.CreateProduct;
using Eshop.Application.EnititiesCommandsQueries.Products.Commands.UpdateProduct;
using Eshop.Application.EnititiesCommandsQueries.Products.Commands.DeleteProduct;
using Eshop.Application.EnititiesCommandsQueries.Products.Queries;
using Eshop.Application.EnititiesCommandsQueries.Products.Queries.GetProduct;
using Eshop.Application.EnititiesCommandsQueries.Products.Queries.SearchProduct;
using Eshop.Application.Common;
using Eshop.Application.EnititiesCommandsQueries.Products.Queries.GetProductsPaged;
using Eshop.Application.Common.Filters.AuxParams;
using Eshop.Application.EnititiesCommandsQueries.Search.Queries.SearchEntitiesParameters;
using Eshop.Domain.Enitities.ProductEnitties;
using Eshop.Application.Interfaces;

namespace Eshop.WebApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {

        private readonly ISender _sender;
        private readonly IGenericTypeMediator _genericTypeMediator;

        public ProductsController(ISender sender, IGenericTypeMediator genericTypeMediator)
        {
            _sender = sender;
            _genericTypeMediator = genericTypeMediator;
        }

        [HttpGet]
        public async Task<OperationResult<IList<ProductDto>>> GetProducts()
        {
            return await _sender.Send(new GetProductsQuery());
        }

        [HttpPost("get-paged-list")]
        public async Task<OperationResultList<IList<ProductDto>>> GetProductsPaged(GetProductsPagedModel model ) 
        {
            return await _sender.Send(new GetProductsPagedQuery(model));
        }

        [HttpGet(":id")]
        public async Task<OperationResult<ProductDto>> GetProductDetails([FromQuery] GetProductModel product)
        {
            return await _sender.Send(new GetProductQuery(new GetProductModel() { Id = product.Id }));
        }

        [HttpPut("update")]
        public async Task<OperationResult<ProductDto>> UpdateAsync([FromBody] UpdateProductModel product)
        {
            return await _sender.Send(new UpdateProductCommand(product));
        }


        [HttpPost("add-product")]
        public async Task<OperationResult<ProductDto>> AddAsync([FromBody] CreateProductModel product)
        {
            return await _sender.Send(new CreateProductCommand(product));
        }

        [HttpPost("search")]
        public async Task<OperationResult<IList<ProductDto>>> SearchProducts([FromBody] SearchFilterModel filterModel)
        {
            return await _sender.Send(new SearchProductQuery(filterModel));
        }

        [HttpPost("serch-ext")]
        public async Task<PagedList<ProductDto>> SearchExt([FromBody] AuxParams auxParams)
        {
            return await _genericTypeMediator.Sender.Send(new SearchEntitiesParametersQuery<Product, ProductDto>(auxParams));
        }

        [HttpDelete("delete")]
        public async Task<OperationResult<EmptyResult>> DeleteAsync([FromBody] DeleteProductModel product)
        {
            return await _sender.Send(new DeleteProductCommand(product) );
        }

    }
}
