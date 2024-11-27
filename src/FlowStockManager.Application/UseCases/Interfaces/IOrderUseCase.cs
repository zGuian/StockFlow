using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.OrderRequest;
using FlowStockManager.Infra.CrossCutting.DTOs.Orders;

namespace FlowStockManager.Application.UseCases.Interfaces
{
    public interface IOrderUseCase
    {
        Order CreateOrder(CreateOrderRequest orderRequest);
        OrderDto ToDto(Order entity);
    }
}
