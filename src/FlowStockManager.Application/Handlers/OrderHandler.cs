using FlowStockManager.Application.Handlers.Interfaces;
using FlowStockManager.Application.Services.Interfaces;
using FlowStockManager.Application.UseCases.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Entities.Enums;
using FlowStockManager.Domain.Requests.OrderRequest;
using FlowStockManager.Domain.Responses.OrderResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Orders;

namespace FlowStockManager.Application.Handlers
{
    public class OrderHandler : IOrderHandler
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IOrderUseCase _orderUseCase;
        private readonly IProductUseCase _productUseCase;
        private readonly IOrderProductService _orderProductService;
        private readonly IClientService _clientService;

        public OrderHandler(IOrderService serviceOrder, IOrderUseCase useCase, IProductService productService,
            IProductUseCase productUseCase, IOrderProductService orderProductService, IClientService clientService)
        {
            _orderService = serviceOrder;
            _orderUseCase = useCase;
            _productService = productService;
            _productUseCase = productUseCase;
            _orderProductService = orderProductService;
            _clientService = clientService;
        }

        public async Task<OrderResponseView<OrderDto>> GetOrdersAsync()
        {
            var orders = await _orderService.GetOrderAsync();
            var dto = _orderUseCase.EnumerableToDto(orders);
            return OrderResponseView<OrderDto>.Factories.CreateResponseView(dto);
        }

        public async Task<OrderResponseView<OrderDto>> RegisterOrderAsync(CreateOrderRequest orderRequest)
        {
            var products = _productUseCase.EnumerableToEntity(orderRequest.Products);
            if (!_productService.VerifyDisponible(products))
            {
                throw new NotImplementedException("Não tem produto disponivel");
            }
            var client = await _clientService.GetAsync(orderRequest.ClientId);
            var order = _orderUseCase.CreateOrder(orderRequest, client);
            await _orderService.RegisterAsync(order);
            order = await _orderProductService.RegisterAsync(order.OrderProducts);
            var dto = _orderUseCase.ToDto(order);
            return OrderResponseView<OrderDto>.Factories.CreateResponseView(new[] { dto });
        }

        public async Task<OrderResponseView<OrderDto>> ProcessOrderAsync(Guid orderId)
        {
            var order = await _orderService.GetOrderAsync(orderId);
            if (!_productService.VerifyDisponible(order.OrderProducts))
            {
                throw new NotImplementedException("Não tem produto disponivel");
            }
            order = Order.UpdateOrderStatus(order, OrderStatus.Processed);
            var products = await _orderProductService.GetProductsAsync(order.OrderProducts);
            await _productService.ConsumeProducts(products);
            await _orderService.UpdateAsync(order);
            var dto = _orderUseCase.ToDto(order);
            return OrderResponseView<OrderDto>.Factories.CreateResponseView(new[] { dto });
        }
    }
}
