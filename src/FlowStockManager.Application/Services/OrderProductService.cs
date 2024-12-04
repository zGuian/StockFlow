using FlowStockManager.Application.Services.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces;

namespace FlowStockManager.Application.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderProductRepository _repository;

        public OrderProductService(IProductService productService, IOrderService orderService, 
            IOrderRepository orderRepository, IProductRepository productRepository, IOrderProductRepository repository)
        {
            _productService = productService;
            _orderService = orderService;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(IEnumerable<OrderProduct> orderProducts)
        {
            var listIdsProduct = orderProducts.Select(op => op.Product.Id);
            var products = await _productRepository.FindDataBaseAsync(listIdsProduct.ToList());
            return products;
        }

        public async Task<Order> RegisterAsync(IEnumerable<OrderProduct> orderProducts)
        { 
            return await _repository.RegisterDataBaseAsync(orderProducts);
        }
    }
}
