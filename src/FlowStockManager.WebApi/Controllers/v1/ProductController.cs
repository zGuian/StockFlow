using FlowStockManager.Application.Handlers.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Domain.Responses.SupplierResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace FlowStockManager.WebApi.Controllers.v1
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

        [EndpointSummary("Obtem todos produtos com base nos parametros")]
        [HttpGet("ProductGetAll", Order = 0)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SupplierResponseView<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetAllProduct([FromQuery] int take = 12, [FromQuery] int skip = 0)
        {
            return Ok(await _handler.GetProductsAsync(take, skip));
        }

        [EndpointSummary("Obter produto pelo ID")]
        [HttpGet("ProductGetById/{id:guid}", Order = 1)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SupplierResponseView<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetByIdProduct(Guid id)
        {
            return Ok(await _handler.GetProductsAsync(id));
        }

        [EndpointSummary("Registra novo produto")]
        [HttpPost("ProductRegister", Order = 2)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SupplierResponseView<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> RegisterProduct([FromBody] CreateProductRequest productRequest)
        {
            var product = await _handler.RegisterProductAsync(productRequest);
            return StatusCode(StatusCodes.Status201Created, product);
        }

        [EndpointSummary("Atualiza informações do produto")]
        [HttpPut("ProductUpdate", Order = 3)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SupplierResponseView<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest productRequest)
        {
            return Ok(await _handler.UpdateProductAsync(productRequest));
        }

        [EndpointSummary("Remove produto do banco de dados")]
        [HttpDelete("ProductDelete/{id:guid}", Order = 4)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _handler.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
