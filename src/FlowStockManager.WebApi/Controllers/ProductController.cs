using FlowStockManager.Application.Handlers.Interfaces;
using FlowStockManager.Domain.Requests.ProductRequests;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace FlowStockManager.WebApi.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductHandler _handler;

        public ProductController(IProductHandler handler)
        {
            _handler = handler;
        }

        [HttpGet("ProductGetAll", Order = 0)]
        public async Task<IActionResult> GetAllProduct([FromQuery] int take = 12, [FromQuery] int skip = 0)
        {
            return Ok(await _handler.GetProductsAsync(take, skip));
        }

        [HttpGet("ProductGetById/{id:guid}", Order = 1)]
        public async Task<IActionResult> GetByIdProduct(Guid id)
        {
            return Ok(await _handler.GetProductsAsync(id));
        }

        [HttpPost("ProductRegister", Order = 2)]
        public async Task<IActionResult> RegisterProduct([FromBody] CreateProductRequest productRequest)
        {
            var product = await _handler.RegisterProductAsync(productRequest);
            return StatusCode(StatusCodes.Status201Created, product);
        }

        [HttpPut("ProductUpdate", Order = 3)]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest productRequest)
        {
            return Ok(await _handler.UpdateProductAsync(productRequest));
        }

        [HttpDelete("ProductDelete/{id:guid}", Order = 4)]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _handler.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
