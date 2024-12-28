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
        private readonly IOrderProductService _orderProductService;
        private readonly IClientService _clientService;

        public OrderHandler(IUnitOfWork unitOfWork, IOrderService serviceOrder, IOrderUseCase useCase, IProductService productService,
            IOrderProductService orderProductService, IClientService clientService)
        {
            _orderService = serviceOrder;
            _orderUseCase = useCase;
            _productService = productService;
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
            client.VerifyClientActived();
            var order = _orderUseCase.CreateOrder(client);
            var dict = CreateDictionary(orderRequest);
            var tuple = await ProductDisponible(dict);
            await _orderService.RegisterAsync(order);
            var op = OrderProduct.Factories.NewOrderProduct(order, tuple);
            order.AddOrderProducts(op);
            order = await _orderProductService.RegisterAsync(op);
            await _unitOfWork.CommitAsync();
            var dto = _orderUseCase.ToDto(order);
            return Response<OrderDto>.Factories.CreateResponse(dto, true);
        }

        public async Task ProcessOrderAsync(Guid id)
        {
            var orderProduct = await _orderProductService.GetAsync(id);
            var order = orderProduct.First().Orders;
            order.UpdateOrderStatusForProcessed();
            await _orderService.UpdateAsync(order);
            var tuple = CreateTuple(orderProduct);
            await _productService.ConsumeProductsAsync(tuple);
            await _unitOfWork.CommitAsync();
        }

        private async Task<IEnumerable<Tuple<Product, int>>> ProductDisponible(Dictionary<Guid, int> dict)
        {
            var tuple = await _productService.VerifyDisponibleAndReturnProduct(dict) 
                ?? throw new NotImplementedException("Não tem produto disponivel");
            return tuple;
        }

        private static Dictionary<Guid, int> CreateDictionary(CreateOrderRequest orderRequest)
        {
            var dictionary = new Dictionary<Guid, int>();
            foreach (var item in orderRequest.Products)
            {
                dictionary.Add(item.ProductId, item.QtdProduct);
            }
            return dictionary;
        }

        private static List<Tuple<Product, int>> CreateTuple(IEnumerable<OrderProduct> orderProducts)
        {
            var tuple = new List<Tuple<Product, int>>();
            foreach (var item in orderProducts)
            {
                tuple.Add(Tuple.Create(item.Product, item.ProductQuantity));
            }
            return tuple;
        }
    }
}
