using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAsync();
        Task<Order> GetAsync(Guid orderId);
        Task<Order> RegisterDataBaseAsync(Order order);
        Task UpdateDataBaseAsync(Order order);
    }
}
