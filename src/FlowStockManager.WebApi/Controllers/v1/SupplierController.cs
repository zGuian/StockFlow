using FlowStockManager.Domain.DTOs.Suppliers;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.Handlers;
using FlowStockManager.Domain.Requests.SupplierRequests;
using FlowStockManager.Domain.Responses.SupplierResponse;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace FlowStockManager.WebApi.Controllers.v1
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

        [EndpointSummary("Obtem todos fornecedores com base nos parametros passado")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SupplierResponseView<SupplierDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        [HttpGet("SupplierGetAll", Order = 0)]
        public async Task<IActionResult> GetAll([FromQuery] int skip, [FromQuery] int take)
        {
            return Ok(await _handler.GetSuppliersAsync(skip, take));
        }

        [EndpointSummary("Obtem fornecedor com base no ID passado como parametro")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SupplierResponseView<SupplierDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        [HttpGet("SupplierGetById/{id:guid}", Order = 1)]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _handler.GetSuppliersAsync(id));
        }

        [EndpointSummary("Registra novo fornecedor")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SupplierResponseView<SupplierDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [HttpPost("SupplierRegister", Order = 2)]
        public async Task<IActionResult> Register([FromBody] CreateSupplierRequest supplierRequest)
        {
            var supplier = await _handler.RegisterSupplierAsync(supplierRequest);
            return StatusCode(StatusCodes.Status201Created, supplier);
        }

        [EndpointSummary("Atualiza informações do fornecedor")]
        [HttpPut("SupplierUpdate", Order = 3)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SupplierResponseView<SupplierDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Update([FromBody] UpdateSupplierRequest supplierRequest)
        {
            return Ok(await _handler.UpdateSupplierAsync(supplierRequest));
        }

        [EndpointSummary("Remove fornecedor do banco de dados")]
        [HttpDelete("SupplierDelete/{id:guid}", Order = 4)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _handler.DeleteSupplier(id);
            return NoContent();
        }
    }
}
