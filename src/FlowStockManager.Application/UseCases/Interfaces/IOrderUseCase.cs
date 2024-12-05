using FlowStockManager.Domain.Entities;
using FlowStockManager.Infra.CrossCutting.DTOs.Orders;

namespace FlowStockManager.Application.UseCases.Interfaces
{
    public interface IOrderUseCase
    {
        Order CreateOrder(Client client);
        OrderDto ToDto(Order entity);
        IEnumerable<OrderDto> EnumerableToDto(IEnumerable<Order> orders);
    }
}
