using FlowStockManager.Application.Services.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces;

namespace FlowStockManager.Application.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _repository;

        public OrderProductService(IOrderProductRepository repository)
        {
            _repository = repository;
        }

        public async Task ConsumeProducts(IEnumerable<OrderProduct> orderProduct, Order order) => await _repository.ConsumeAsync(orderProduct, order);

        public async Task<IEnumerable<OrderProduct>> GetAsync(Guid orderId) => await _repository.FindDataBaseAsync(orderId);

        public async Task<Order> RegisterAsync(IEnumerable<OrderProduct> orderProducts) => await _repository.RegisterDataBaseAsync(orderProducts);
    }
}
