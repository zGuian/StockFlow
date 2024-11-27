using FlowStockManager.Domain.Requests.OrderRequest;
using FlowStockManager.Domain.Responses.ProductResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Orders;

namespace FlowStockManager.Application.Handlers.Interfaces
{
    public interface IOrderHandler
    {
        Task<OrderResponseView<OrderDto>> RegisterOrderAsync(CreateOrderRequest orderRequest);
    }
}
