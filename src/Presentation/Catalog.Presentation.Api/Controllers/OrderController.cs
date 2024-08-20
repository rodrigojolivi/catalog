using Catalog.Core.Application.Features.Orders.CreateOrder;
using Catalog.Core.Application.Features.Orders.DeleteOrder;
using Catalog.Core.Application.Features.Orders.FindOrder;
using Catalog.Core.Application.Features.Orders.GetOrders;
using Catalog.Core.Application.Features.Orders.GetOrdersByCustomer;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Presentation.Api.Controllers
{
    [Route("api/orders")]
    public class OrderController : CustomController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator) => _mediator = mediator;

        [Authorize(Roles = ROLE_SELLER)]
        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync([FromQuery] GetOrdersQuery query)
        {
            var response = await _mediator.Send(query);

            if (HasNotifications(response)) return BadRequest(response);

            return Ok(response);
        }

        [Authorize(Roles = ROLE_CUSTOMER)]
        [HttpGet("customers")]
        public async Task<IActionResult> GetOrdersByCustomerAsync([FromQuery] GetOrdersByCustomerQuery query)
        {
            var response = await _mediator.Send(query);

            if (HasNotifications(response)) return BadRequest(response);

            return Ok(response);
        }

        [Authorize(Roles = ROLE_CUSTOMER)]
        [HttpGet("{idOrder:guid}")]
        public async Task<IActionResult> FindOrderAsync([FromRoute] Guid idOrder)
        {
            var query = new FindOrderQuery
            {
                IdOrder = idOrder
            };

            var response = await _mediator.Send(query);

            if (NoData(response)) return NotFound();

            if (HasNotifications(response)) return BadRequest(response);

            return Ok(response);
        }

        [Authorize(Roles = ROLE_SELLER)]
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderCommand command)
        {
            var response = await _mediator.Send(command);

            if (HasNotifications(response)) return BadRequest(response);

            return Created();
        }

        [Authorize(Roles = ROLE_SELLER)]
        [HttpDelete("{idOrder:guid}")]
        public async Task<IActionResult> DeleteOrderAsync([FromRoute] Guid idOrder)
        {
            var command = new DeleteOrderCommand
            {
                IdOrder = idOrder
            };

            var response = await _mediator.Send(command);

            if (HasNotifications(response)) return BadRequest(response);

            return NoContent();
        }
    }
}
