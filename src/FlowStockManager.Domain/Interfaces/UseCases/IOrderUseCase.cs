using FlowStockManager.Domain.DTOs.Orders;
using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.UseCases
{
    public interface IOrderUseCase
    {
        Order CreateOrder(Client client);
        OrderDto ToDto(Order entity);
        IEnumerable<OrderDto> EnumerableToDto(IEnumerable<Order> orders);
    }
}
