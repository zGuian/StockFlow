using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> RegisterDataBaseAsync(Order order);
    }
}
