using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Repositories
{
    public interface IOrderProductRepository
    {
        Task ConsumeAsync(Order order);
        Task<Order> RegisterDataBaseAsync(IEnumerable<OrderProduct> orderProducts);
        Task<IEnumerable<OrderProduct>> FindAllProductByOrder(Guid id);
    }
}
