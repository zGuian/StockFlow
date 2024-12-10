﻿using FlowStockManager.Domain.DTOs.Orders;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.Handlers;
using FlowStockManager.Domain.Requests.OrderRequest;
using FlowStockManager.Domain.Responses.OrderResponse;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace FlowStockManager.WebApi.Controllers.v1
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderHandler _handler;

        public OrderController(IOrderHandler handler)
        {
            _handler = handler;
        }

        [EndpointSummary("Busca detalhes de pedido especifico")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OrderResponseView))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [HttpGet("GetOrdersDetails", Order = 0)]
        public async Task<IActionResult> GetDetails([FromQuery] Guid id)
        {
            var orders = await _handler.GetOrdersAsync(id);
            return Ok(orders);
        }

        [EndpointSummary("Busca todos pedidos que não foram processados")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OrderResponseView))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [HttpGet("GetOrders", Order = 1)]
        public async Task<IActionResult> Get()
        {
            var orders = await _handler.GetOrdersAsync();
            return Ok(orders);
        }

        [EndpointSummary("Registra novo pedido")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OrderResponseView))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [HttpPost("OrderRegister", Order = 2)]
        public async Task<IActionResult> Register([FromBody] CreateOrderRequest orderRequest)
        {
            var order = await _handler.RegisterOrderAsync(orderRequest);
            return Ok(order);
        }

        [EndpointSummary("Processa pedidos já registrado")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [HttpPost("ProcessOrder", Order = 3)]
        public async Task<IActionResult> ProcessOrder([FromQuery] Guid orderId)
        {
            await _handler.ProcessOrderAsync(orderId);
            return NoContent();
        }
    }
}
