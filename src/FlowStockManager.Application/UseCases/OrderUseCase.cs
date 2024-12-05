using AutoMapper;
using FlowStockManager.Application.UseCases.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Infra.CrossCutting.DTOs.Orders;

namespace FlowStockManager.Application.UseCases
{
    public class OrderUseCase : IOrderUseCase
    {
        private readonly IMapper _mapper;

        public OrderUseCase(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Order CreateOrder(Client client)
        {
            return Order.Factories.NewOrder(client);
        }

        public IEnumerable<OrderDto> EnumerableToDto(IEnumerable<Order> orders)
        {
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public OrderDto ToDto(Order entity)
        {
            return _mapper.Map<OrderDto>(entity);
        }
    }
}
