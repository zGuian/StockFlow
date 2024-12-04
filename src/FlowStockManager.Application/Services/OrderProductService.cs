using FlowStockManager.Application.Services.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces;

namespace FlowStockManager.Application.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderProductRepository _repository;

        public OrderProductService(IProductRepository productRepository, IOrderProductRepository repository)
        {
            _productRepository = productRepository;
            _repository = repository;
        }

        public async Task<Order> RegisterAsync(IEnumerable<OrderProduct> orderProducts)
        { 
            return await _repository.RegisterDataBaseAsync(orderProducts);
        }
    }
}
