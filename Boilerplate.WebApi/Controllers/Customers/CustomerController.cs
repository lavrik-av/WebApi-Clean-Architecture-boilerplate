using Eshop.Application.Common;
using Eshop.Application.Dto.Customer;
using Eshop.Application.EnititiesCommandsQueries.Customers.Commands.CreateCustomer;
using Eshop.Application.EnititiesCommandsQueries.Customers.Queries.GetCustomers;
using Eshop.Application.EnititiesCommandsQueries.Customers.Queries.GetCustomersOrdersProductsTotals;
using Eshop.Domain.Enitities.CusomerEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.WebApi.Controllers.Customers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _sender;

        public CustomerController(IMediator mediator)
        {
            _sender = mediator;
        }

        [HttpPost("add-customer")]
        public async Task<OperationResult<CustomerDto>> AddAsync ([FromBody] CreateCustomerModel model)
        {
            return await _sender.Send(new CreateCustomerCommand(model));
        }

        [HttpGet]
        public async Task<OperationResult<IList<CustomerOrdersDto>>> GetAllAsync()
        {
            return await _sender.Send(new GetCustomersQuery());
        }

        [HttpGet("customers-orders-products")]
        public async Task<PagedList<CustomersOrdersProductsTotals>> CustomersOrdersProductsTotals()
        {
            return await _sender.Send(new GetCustomersOrdersProductsTotals());
        }
    }
}
