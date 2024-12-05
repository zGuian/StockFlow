using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces
{
    public interface IOrderProductRepository
    {
        Task ConsumeAsync(IEnumerable<OrderProduct> orderProduct, Order order);
        Task<IEnumerable<OrderProduct>> FindDataBaseAsync(Guid orderId);
        Task<Order> RegisterDataBaseAsync(IEnumerable<OrderProduct> orderProducts);
    }
}
