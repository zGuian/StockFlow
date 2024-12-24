using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Entities.Enums;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Services;

namespace FlowStockManager.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository _repository;

        public OrderService(IUnitOfWork unitOfWork, IOrderRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<IEnumerable<Order>> GetOrderAsync() =>
            await _repository.FindEverythingWithPendingStatusAsync(o => o.OrderStatus == OrderStatus.Pending);

        public async Task<Order> GetOrderAsync(Guid orderId) =>
            await _repository.FindDataBaseAsync(orderId);

        public async Task<Order> RegisterAsync(Order order)
        {
            order = await _unitOfWork.OrderRepository.RegisterDataBaseAsync(order);
            return order;
        }

        public async Task UpdateAsync(Order order)
        {
            await _repository.UpdateDataBaseAsync(order);
        }
    }
}
