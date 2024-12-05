using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Application.Services.Interfaces
{
    public interface IOrderProductService
    {
        Task<IEnumerable<OrderProduct>> GetAsync(Guid orderId);
        Task<Order> RegisterAsync(IEnumerable<OrderProduct> orderProduct);
        Task ConsumeProducts(IEnumerable<OrderProduct> orderProduct, Order order);
    }
}
