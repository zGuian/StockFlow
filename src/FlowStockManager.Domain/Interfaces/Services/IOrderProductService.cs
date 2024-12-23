using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Services
{
    public interface IOrderProductService
    {
        Task<IEnumerable<OrderProduct>> GetAsync(Guid id);
        Task<Order> RegisterAsync(IEnumerable<OrderProduct> orderProduct);
        Task ConsumeProducts(IEnumerable<OrderProduct> orderProduct, Order order);
    }
}
