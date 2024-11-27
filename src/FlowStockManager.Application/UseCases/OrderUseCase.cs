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

        public Order CreateOrder(CreateOrderRequest orderRequest)
        {
            var client = _mapper.Map<Client>(orderRequest.ClientId);
            var products = _mapper.Map<IEnumerable<Product>>(orderRequest.ProductsId);
            return Order.Factories.NewOrder(client, products);
        }

        public OrderDto ToDto(Order entity)
        {
            return _mapper.Map<OrderDto>(entity);
        }
    }
}
