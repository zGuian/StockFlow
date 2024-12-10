using FlowStockManager.Domain.Requests.OrderRequest;
using FlowStockManager.Domain.Responses.OrderResponse;

namespace FlowStockManager.Domain.Interfaces.Handlers
{
    public interface IOrderHandler
    {
        Task<OrderResponseView> GetOrdersAsync();
        Task<OrderResponseView> GetOrdersAsync(Guid id);
        Task<OrderResponseView> RegisterOrderAsync(CreateOrderRequest orderRequest, CancellationToken cancellationToken);
        Task ProcessOrderAsync(Guid orderRequest);
    }
}
