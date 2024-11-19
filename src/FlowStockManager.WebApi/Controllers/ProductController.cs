using Asp.Versioning;
using FlowStockManager.Application.Handlers.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Domain.Responses.ProductResponse;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace FlowStockManager.WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    public class ProductController : ControllerBase
    {
        private readonly IProductHandler _handler;

        private ProductController() 
        {
            throw new NotImplementedException();
        }

        public ProductController(IProductHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        [Route("/GetAll", Name = nameof(GetAllProduct), Order = 0)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductResponseView<Product>>))]

        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await _handler.GetProductsAsync());
        }

        [HttpGet]
        [Route("/GetById/{id:guid}", Name = nameof(GetByIdProduct), Order = 1)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductResponseView<Product>))]
        public async Task<IActionResult> GetByIdProduct(Guid id)
        {
            return Ok(await _handler.GetProductsAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductResponseView<Product>))]
        [Route("/Post", Name = nameof(RegisterProduct), Order = 2)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public async Task<IActionResult> RegisterProduct(CreateProductRequest productRequest)
        {
            var product = await _handler.RegisterProductAsync(productRequest);
            return CreatedAtRoute(nameof(GetByIdProduct), product.Object.Id);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductResponseView<Product>))]
        [Route("/Update", Name = nameof(UpdateProduct), Order = 3)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequest productRequest)
        {
            return Ok(await _handler.UpdateProductAsync(productRequest));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ProductResponseView<Product>))]
        [Route("/Delete/{id:guid}", Name = nameof(RegisterProduct), Order = 4)]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _handler.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
