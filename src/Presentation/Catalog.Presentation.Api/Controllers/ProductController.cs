using Catalog.Core.Application.Features.Products.CreateProduct;
using Catalog.Core.Application.Features.Products.DeleteProduct;
using Catalog.Core.Application.Features.Products.FindProduct;
using Catalog.Core.Application.Features.Products.GetProducts;
using Catalog.Core.Application.Features.Products.UpdateProduct;
using Catalog.Core.Application.Features.Stocks.CreateStock;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Presentation.Api.Controllers
{
    [Route("api/products")]
    public class ProductController : CustomController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator) => _mediator = mediator;

        [Authorize(Roles = ROLE_ADMIN)]
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync([FromQuery] GetProductsQuery query)
        {
            var response = await _mediator.Send(query);

            if (HasNotifications(response)) return BadRequest(response);

            return Ok(response);
        }

        [Authorize(Roles = ROLE_ADMIN)]
        [HttpGet("{idProduct:guid}")]
        public async Task<IActionResult> FindProductAsync([FromRoute] Guid idProduct)
        {
            var query = new FindProductQuery
            {
                IdProduct = idProduct
            };

            var response = await _mediator.Send(query);

            if (NoData(response)) return NotFound();

            if (HasNotifications(response)) return BadRequest(response);

            return Ok(response);
        }

        [Authorize(Roles = ROLE_ADMIN)]
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommand command)
        {
            var response = await _mediator.Send(command);

            if (HasNotifications(response)) return BadRequest(response);

            return Created();
        }

        [Authorize(Roles = ROLE_ADMIN)]
        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProductCommand command)
        {
            var response = await _mediator.Send(command);

            if (HasNotifications(response)) return BadRequest(response);

            return NoContent();
        }

        [Authorize(Roles = ROLE_ADMIN)]
        [HttpDelete("{idProduct:guid}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] Guid idProduct)
        {
            var command = new DeleteProductCommand
            {
                IdProduct = idProduct
            };

            var response = await _mediator.Send(command);

            if (HasNotifications(response)) return BadRequest(response);

            return NoContent();
        }

        [Authorize(Roles = ROLE_ADMIN)]
        [HttpPatch("stocks")]
        public async Task<IActionResult> CreateStockAsync([FromBody] CreateStockCommand command)
        {
            var response = await _mediator.Send(command);

            if (HasNotifications(response)) return BadRequest(response);

            return NoContent();
        }
    }
}
