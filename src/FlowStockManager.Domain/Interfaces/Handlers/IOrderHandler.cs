using FlowStockManager.Domain.DTOs.Orders;
using FlowStockManager.Domain.Requests.OrderRequest;
using FlowStockManager.Domain.Responses.OrderResponse;

namespace FlowStockManager.Domain.Interfaces.Handlers
{
    public interface IOrderHandler
    {
        Task<OrderResponseView<OrderDto>> GetOrdersAsync();
        Task<OrderResponseView<OrderDto>> RegisterOrderAsync(CreateOrderRequest orderRequest);
        Task ProcessOrderAsync(Guid orderRequest);
    }
}
