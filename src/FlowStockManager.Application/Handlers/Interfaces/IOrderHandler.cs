using FlowStockManager.Domain.Requests.OrderRequest;
using FlowStockManager.Domain.Responses.OrderResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Orders;

namespace FlowStockManager.Application.Handlers.Interfaces
{
    public interface IOrderHandler
    {
        Task<OrderResponseView<OrderDto>> GetOrdersAsync();
        Task<OrderResponseView<OrderDto>> RegisterOrderAsync(CreateOrderRequest orderRequest);
        Task<OrderResponseView<OrderDto>> ProcessOrderAsync(Guid orderRequest);
    }
}
