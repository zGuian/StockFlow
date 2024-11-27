using FlowStockManager.Application.Handlers.Interfaces;
using FlowStockManager.Domain.Requests.OrderRequest;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace FlowStockManager.WebApi.Controllers
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

        public async Task<IActionResult> Register([FromBody] CreateOrderRequest orderRequest)
        {
            var order = await _handler.RegisterOrderAsync(orderRequest);
            return Ok(order);
        }
    }
}
