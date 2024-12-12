using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Services;

namespace FlowStockManager.Application.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _repository;

        public OrderProductService(IOrderProductRepository repository)
        {
            _repository = repository;
        }

        public async Task ConsumeProducts(IEnumerable<OrderProduct> orderProduct, Order order) =>
            await _repository.ConsumeAsync(orderProduct, order);

        public async Task<IEnumerable<OrderProduct>> GetAsync(Guid id) =>
            await _repository.FindAllProductByOrder(id);

        public async Task<Order> RegisterAsync(IEnumerable<OrderProduct> orderProducts) =>
            await _repository.RegisterDataBaseAsync(orderProducts);
    }
}
