using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Application.Services.Interfaces
{
    public interface IOrderProductService
    {
        Task<Order> RegisterAsync(IEnumerable<OrderProduct> orderProduct);
    }
}
