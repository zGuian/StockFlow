using AutoMapper;
using FlowStockManager.Application.UseCases.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.OrderRequest;
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

        public Order CreateOrder(CreateOrderRequest orderRequest, Client client)
        {
            var pDtoRequest = orderRequest.Products.Select(p => p);
            var products = _mapper.Map<List<Product>>(pDtoRequest);
            return Order.Factories.NewOrder(client, products);
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
