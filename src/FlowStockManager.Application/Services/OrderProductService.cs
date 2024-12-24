using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Services;

namespace FlowStockManager.Application.Services
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderProductRepository _repository;

        public OrderProductService(IUnitOfWork unitOfWork, IOrderProductRepository repository)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task ConsumeProducts(IEnumerable<OrderProduct> orderProduct, Order order) =>
            await _repository.ConsumeAsync(orderProduct, order);

        public async Task<IEnumerable<OrderProduct>> GetAsync(Guid id) =>
            await _repository.FindAllProductByOrder(id);

        public async Task<Order> RegisterAsync(IEnumerable<OrderProduct> orderProduct)
        {
            var order = await _unitOfWork.OrderProductRepository.RegisterDataBaseAsync(orderProduct);
            return order;
        }
    }
}
