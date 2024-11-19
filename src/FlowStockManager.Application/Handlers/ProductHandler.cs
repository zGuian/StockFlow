using FlowStockManager.Application.Handlers.Interfaces;
using FlowStockManager.Application.Services.Interfaces;
using FlowStockManager.Application.UseCases.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Domain.Responses.ProductResponse;

namespace FlowStockManager.Application.Handlers
{
    public class ProductHandler : IProductHandler
    {
        private readonly IProductUseCase _useCase;
        private readonly IProductService _service;

        public ProductHandler(IProductUseCase useCase, IProductService service)
        {
            _useCase = useCase;
            _service = service;
        }

        public async Task<IEnumerable<ProductResponseView<Product>>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductResponseView<Product>> GetProductsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductResponseView<Product>> RegisterProductAsync(CreateProductRequest productRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductResponseView<Product>> UpdateProductAsync(UpdateProductRequest productRequest)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
