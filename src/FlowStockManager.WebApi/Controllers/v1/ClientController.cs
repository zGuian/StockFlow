using FlowStockManager.Application.Handlers.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.ClientRequest;
using FlowStockManager.Domain.Responses.Base;
using FlowStockManager.Domain.Responses.ClientResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Clients;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace FlowStockManager.WebApi.Controllers.v1
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/v1/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientHandler _handler;

        public ClientController(IClientHandler handler)
        {
            _handler = handler;
        }

        [EndpointSummary("Obtem todos clientes cadastrados com base nos parametros")]
        [HttpGet("ClientGetAll", Order = 0)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientResponseView<ClientDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Get(int take, int skip)
        {
            var clients = await _handler.GetAsync(take, skip);
            return Ok(clients);
        }

        [EndpointSummary("Obter cliente pelo ID")]
        [HttpGet("ClientGetById/{id:guid}", Order = 1)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientResponseView<ClientDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Get(Guid id)
        {
            var client = await _handler.GetAsync(id);
            return Ok(client);
        }


        [EndpointSummary("Registra novo cliente")]
        [HttpPost("ClientRegister", Order = 2)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ClientResponseView<ClientDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Post(CreateClientRequest clientRequest)
        {
            var client = await _handler.RegisterAsync(clientRequest);
            return StatusCode(StatusCodes.Status201Created, client);
        }

        [EndpointSummary("Atualiza informações do cliente")]
        [HttpPut("ClientUpdate", Order = 3)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientResponseView<ClientDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Put(UpdateClientRequest clientRequest)
        {
            var client = await _handler.UpdateAsync(clientRequest);
            return Ok(client);
        }

        [EndpointSummary("Remove cliente do banco de dados [SOMENTE SEM PEDIDO PENDENTE]")]
        [HttpDelete("ClienttDelete/{id:guid}", Order = 4)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _handler.DeleteAsync(id);
            return NoContent();
        }
    }
}
