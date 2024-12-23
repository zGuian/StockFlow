using FlowStockManager.Domain.DTOs.Orders;
using FlowStockManager.Domain.Requests.OrderRequest;
using FlowStockManager.Domain.Responses.Base;
using FlowStockManager.Domain.Responses.OrderResponse;

namespace FlowStockManager.Domain.Interfaces.Handlers
{
    public interface IOrderHandler
    {
        Task<ResponsePage<IEnumerable<OrderDto>>> GetOrdersAsync();
        Task<Response<OrderDto>> GetOrdersAsync(Guid id);
        Task<Response<OrderDto>> RegisterOrderAsync(CreateOrderRequest orderRequest);
        Task ProcessOrderAsync(Guid orderRequest);
    }
}
