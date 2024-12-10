using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAsync();
        Task<Order> GetAsync(Guid orderId);
        Task<Order> RegisterDataBaseAsync(Order order, CancellationToken ct);
        Task UpdateDataBaseAsync(Order order);
    }
}
