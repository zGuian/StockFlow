using FlowStockManager.Domain.DTOs.Orders;
using FlowStockManager.Domain.Requests.OrderRequest;
using FlowStockManager.Domain.Responses.Base;

namespace FlowStockManager.Domain.Interfaces.Handlers
{
    public interface IOrderHandler
    {
        Task<ResponsePage<IEnumerable<OrderDto>>> GetOrdersAsync();
        Task<Response<OrderDto>> GetOrdersAsync(Guid id);
        Task ProcessOrderAsync(Guid orderRequest);
        Task<Response<OrderDto>> RegisterOrderAsync(CreateOrderRequest orderRequest);
    }
}
