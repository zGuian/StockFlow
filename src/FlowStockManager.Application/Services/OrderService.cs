using FlowStockManager.Application.Services.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces;

namespace FlowStockManager.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Order> RegisterAsync(Order order)
        {
            return await _repository.RegisterDataBaseAsync(order);
        }
    }
}
