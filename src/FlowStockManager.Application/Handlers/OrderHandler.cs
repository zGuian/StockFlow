using FlowStockManager.Domain.DTOs.Orders;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Entities.Enums;
using FlowStockManager.Domain.Interfaces.Handlers;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Services;
using FlowStockManager.Domain.Interfaces.UseCases;
using FlowStockManager.Domain.Requests.OrderRequest;
using FlowStockManager.Domain.Responses.Base;

namespace FlowStockManager.Application.Handlers
{
    public class OrderHandler : IOrderHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IOrderUseCase _orderUseCase;
        private readonly IProductUseCase _productUseCase;
        private readonly IOrderProductService _orderProductService;
        private readonly IClientService _clientService;

        public OrderHandler(IUnitOfWork unitOfWork, IOrderService serviceOrder, IOrderUseCase useCase, IProductService productService,
            IProductUseCase productUseCase, IOrderProductService orderProductService, IClientService clientService)
        {
            _orderService = serviceOrder;
            _orderUseCase = useCase;
            _productService = productService;
            _productUseCase = productUseCase;
            _orderProductService = orderProductService;
            _clientService = clientService;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponsePage<IEnumerable<OrderDto>>> GetOrdersAsync()
        {
            var orders = await _orderService.GetOrderAsync();
            var dto = _orderUseCase.EnumerableToDto(orders);
            return ResponsePage<IEnumerable<OrderDto>>.Factories.CreateResponsePaged(dto, dto.Count());
        }

        public async Task<Response<OrderDto>> GetOrdersAsync(Guid id)
        {
            var order = await _orderService.GetOrderAsync(id);
            var dto = _orderUseCase.ToDto(order);
            return Response<OrderDto>.Factories.CreateResponse(dto, true);
        }

        public async Task<Response<OrderDto>> RegisterOrderAsync(CreateOrderRequest orderRequest)
        {
            var client = await _clientService.GetAsync(orderRequest.ClientId);
            ClientActived(client);
            var products = _productUseCase.EnumerableToEntity(orderRequest.Products);
            ProductDisponible(products);
            var order = _orderUseCase.CreateOrder(client);
            await _orderService.RegisterAsync(order);
            products = await _productService.GetAsync(products);
            Order.AddOrderProducts(order, OrderProduct.Factories.NewOrderProduct(
                order, products, orderRequest.Products.Select(p => p.QtdProduct)));
            order = await _orderProductService.RegisterAsync(order.OrderProducts);
            order = await _orderService.GetOrderAsync(order.Id);
            var dto = _orderUseCase.ToDto(order);
            await _unitOfWork.CommitAsync();
            return Response<OrderDto>.Factories.CreateResponse(dto, true);
        }

        public async Task ProcessOrderAsync(Guid orderId)
        {
            var orderProduct = await _orderProductService.GetAsync(orderId);
            var order = orderProduct.First().Orders;
            Order.UpdateOrderStatus(order, OrderStatus.Processed);
            OrderProduct.UpdateOrder(orderProduct, order);
            await _orderProductService.ConsumeProducts(orderProduct, order);
            await _unitOfWork.CommitAsync();
        }

        private static void ClientActived(Client client)
        {
            if (!client.IsActive)
            {
                throw new Exception("Cliente não esta ativo, impossibilitando de realizar a criação do pedido!");
            }
        }

        private void ProductDisponible(IEnumerable<Product> products)
        {
            if (!_productService.VerifyDisponible(products))
            {
                throw new NotImplementedException("Não tem produto disponivel");
            }
        }
    }
}
