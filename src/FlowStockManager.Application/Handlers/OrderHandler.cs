using FlowStockManager.Application.Handlers.Interfaces;
using FlowStockManager.Application.Services.Interfaces;
using FlowStockManager.Application.UseCases.Interfaces;
using FlowStockManager.Domain.Requests.OrderRequest;
using FlowStockManager.Domain.Responses.ProductResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Orders;

namespace FlowStockManager.Application.Handlers
{
    public class OrderHandler : IOrderHandler
    {
        private readonly IOrderService _serviceOrder;
        private readonly IProductService _productService;
        private readonly IOrderUseCase _useCase;

        public OrderHandler(IOrderService serviceOrder, IOrderUseCase useCase, IProductService productService)
        {
            _serviceOrder = serviceOrder;
            _useCase = useCase;
            _productService = productService;
        }

        public async Task<OrderResponseView<OrderDto>> RegisterOrderAsync(CreateOrderRequest orderRequest)
        {
            var entity = _useCase.CreateOrder(orderRequest);
            if (_productService.VerifyDisponible(entity.Products))
            {
                entity = await _serviceOrder.RegisterAsync(entity);
                var dto = _useCase.ToDto(entity);
                return OrderResponseView<OrderDto>.Factories.CreateResponseView(dto);
            }
            throw new NotImplementedException("Não tem produto disponivel");
        }
    }
}
