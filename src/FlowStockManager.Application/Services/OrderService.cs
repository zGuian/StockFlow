using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Services;

namespace FlowStockManager.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Order>> GetOrderAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<Order> GetOrderAsync(Guid orderId)
        {
            return await _repository.GetAsync(orderId);
        }

        public async Task<Order> RegisterAsync(Order order, CancellationToken ct)
        {
            return await _repository.RegisterDataBaseAsync(order, ct);
        }

        public Task<Order> RegisterAsync(Order order, IEnumerable<Product> products)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Order order) => await _repository.UpdateDataBaseAsync(order);
    }
}
