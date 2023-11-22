using Eshop.Application.Common;
using Eshop.Application.EnititiesCommandsQueries.ComplexQuery.Queries;
using Eshop.Application.EnititiesCommandsQueries.Customers.Queries.GetCustomersOrders;
using Eshop.Domain.Enitities.CusomerEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.WebApi.Controllers.ComplexQueries
{
    [ApiController]
    [Route("api/complex-queries")]
    public class ComplexQueriesController : ControllerBase
    {
        private readonly IMediator _sender;

        public ComplexQueriesController(IMediator sender)
        {
            _sender = sender;
        }

        [HttpGet("/order-products")]
        public async Task<OperationResultList<IList<ComplexQueryModel>>> MakeComplexQuery()
        {
            return await _sender.Send(new GetComplexQuery(new ComplexQueryModel()));
        }

        //[HttpGet("/customer-products")]
        //public async Task<IList<CustomerOrdersProducts>> GetCustomersOrdersProducts()
        //{
        //    return await _sender.Send(new GetCustomersOrders());
        //}

    }
}
