using FlowStockManager.Domain.DTOs.Products;
using FlowStockManager.Domain.Interfaces.Handlers;
using FlowStockManager.Domain.Interfaces.Services;
using FlowStockManager.Domain.Interfaces.UseCases;
using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Domain.Responses.ProductResponse;

namespace FlowStockManager.Application.Handlers
{
    public class ProductHandler : IProductHandler
    {
        private readonly IProductUseCase _useCase;
        private readonly IProductService _serviceProduct;

        public ProductHandler(IProductUseCase useCase, IProductService service)
        {
            _useCase = useCase;
            _serviceProduct = service;
        }

        public async Task<ProductResponseView<ProductDto>> GetProductsAsync(int take, int skip)
        {
            var products = await _serviceProduct.GetAsync(take, skip);
            var dtos = _useCase.EnumerableToDto(products);
            return ProductResponseView<ProductDto>.Factories.CreateResponseView(dtos);
        }

        public async Task<ProductResponseView<ProductDto>> GetProductsAsync(Guid id)
        {
            var product = await _serviceProduct.GetAsync(id);
            var dto = _useCase.ToDto(product);
            return ProductResponseView<ProductDto>.Factories.CreateResponseView(new[] { dto });
        }

        public async Task<ProductResponseView<ProductDto>> RegisterProductAsync(CreateProductRequest productRequest)
        {
            var entity = _useCase.CreateProduct(productRequest, productRequest.SupplierId);
            entity = await _serviceProduct.RegisterAsync(entity);
            var dto = _useCase.ToDto(entity);
            return ProductResponseView<ProductDto>.Factories.CreateResponseView(new[] { dto });
        }

        public async Task<ProductResponseView<ProductDto>> UpdateProductAsync(UpdateProductRequest productRequest)
        {
            var entity = _useCase.ToEntity(productRequest);
            entity = await _serviceProduct.UpdateAsync(entity);
            var dto = _useCase.ToDto(entity);
            return ProductResponseView<ProductDto>.Factories.CreateResponseView(new[] { dto });
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _serviceProduct.DeleteAsync(id);
        }
    }
}
