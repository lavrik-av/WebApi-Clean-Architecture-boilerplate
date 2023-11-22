using Eshop.Application.Common;
using Eshop.Application.Dto.Order;
using Eshop.Application.EnititiesCommandsQueries.Orders.Commands.AddOrder;
using Eshop.Application.EnititiesCommandsQueries.Orders.Queries.GetOrders;
using Eshop.Domain.Enitities.OrderEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.WebApi.Controllers.Orders
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _sender;

        public OrderController(IMediator sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public Task<OperationResult<IList<OrderDto>>> GetAllAsync()
        {
            return _sender.Send(new GetOrdersQuery());
        }

        [HttpPost("add-order")]
        public async Task<OperationResult<OrderDto>> AddAsync(AddOrderModel model)
        {
            return await _sender.Send(new AddOrderCommand(model));
        }
    }
}
