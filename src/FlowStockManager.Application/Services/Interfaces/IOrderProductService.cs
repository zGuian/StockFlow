using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Application.Services.Interfaces
{
    public interface IOrderProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync(IEnumerable<OrderProduct> orderProducts);
        Task<Order> RegisterAsync(IEnumerable<OrderProduct> orderProduct);
    }
}
