using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Application.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> RegisterAsync(Order entity);
    }
}
