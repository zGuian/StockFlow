using FlowStockManager.Application.ProductApp.Interfaces;
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
        [EndpointSummary("Obtem todos produtos com base nos parametros")]
        [HttpGet("ProductGetAll", Order = 0)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SupplierResponseView<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetAllProduct([FromServices] IGetProductsPageableQuery getPageable, [FromQuery] int take = 12, [FromQuery] int skip = 0)
        {
            return Ok(await getPageable.ExecuteAsync(take, skip));
        }

        [EndpointSummary("Obter produto pelo ID")]
        [HttpGet("ProductGetById/{id:guid}", Order = 1)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SupplierResponseView<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetByIdProduct([FromServices] IGetProductByIdQuery getById, Guid id)
        {
            return Ok(await getById.ExecuteAsync(id));
        }

        [EndpointSummary("Registra novo produto")]
        [HttpPost("ProductRegister", Order = 2)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SupplierResponseView<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> RegisterProduct([FromServices] ICreateProductCommand create, [FromBody] CreateProductRequest productRequest)
        {
            var product = await create.ExecuteAsync(productRequest);
            return StatusCode(StatusCodes.Status201Created, product);
        }

        [EndpointSummary("Atualiza informações do produto")]
        [HttpPut("ProductUpdate", Order = 3)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SupplierResponseView<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> UpdateProduct([FromServices] IUpdateProductCommand update, [FromBody] UpdateProductRequest productRequest)
        {
            return Ok(await update.ExecuteAsync(productRequest));
        }

        [EndpointSummary("Remove produto do banco de dados")]
        [HttpDelete("ProductDelete/{id:guid}", Order = 4)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteProduct([FromServices] IDeleteProductCommand delete, Guid id)
        {
            await delete.ExecuteAsync(id);
            return NoContent();
        }

        public async Task<IActionResult> ConsumeProduct([FromServices] IConsumeProductCommand consume, 
            [FromBody] ConsumeProductRequest[] request)
        {
            await consume.ExecuteAsync(request);
            return NoContent();
        }
    }
}
