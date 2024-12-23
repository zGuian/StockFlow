using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Repositories
{
    public interface IOrderProductRepository
    {
        Task ConsumeAsync(IEnumerable<OrderProduct> orderProduct, Order order);
        Task<Order> RegisterDataBaseAsync(IEnumerable<OrderProduct> orderProducts);
        Task<IEnumerable<OrderProduct>> FindAllProductByOrder(Guid id);
    }
}
