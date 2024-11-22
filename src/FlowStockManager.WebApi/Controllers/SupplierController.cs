using FlowStockManager.Application.Handlers.Interfaces;
using FlowStockManager.Domain.Requests.SupplierRequests;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace FlowStockManager.WebApi.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/v1/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierHandler _handler;

        public SupplierController(ISupplierHandler handler)
        {
            _handler = handler;
        }

        [HttpGet("SupplierGetAll", Order = 0)]
        public async Task<IActionResult> GetAll([FromQuery] int skip, [FromQuery] int take)
        {
            return Ok(await _handler.GetSuppliersAsync(skip, take));
        }

        [HttpGet("SupplierGetById/{id:guid}", Order = 1)]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _handler.GetSuppliersAsync(id));
        }

        [HttpPost("SupplierRegister", Order = 2)]
        public async Task<IActionResult> Register([FromBody] CreateSupplierRequest supplierRequest)
        {
            var supplier = await _handler.RegisterSupplierAsync(supplierRequest);
            return StatusCode(StatusCodes.Status201Created, supplier);
        }

        [HttpPut("SupplierUpdate", Order = 3)]
        public async Task<IActionResult> Update([FromBody] UpdateSupplierRequest supplierRequest)
        {
            return Ok(await _handler.UpdateSupplierAsync(supplierRequest));
        }

        [HttpDelete("SupplierDelete/{id:guid}", Order = 4)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _handler.DeleteSupplier(id);
            return NoContent();
        }
    }
}
