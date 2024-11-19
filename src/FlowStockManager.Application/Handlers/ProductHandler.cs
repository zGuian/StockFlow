using FlowStockManager.Application.Handlers.Interfaces;
using FlowStockManager.Application.Services.Interfaces;
using FlowStockManager.Application.UseCases.Interfaces;
using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Domain.Responses.ProductResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;

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

        public async Task<ProductResponseView<ProductDto>> GetProductsAsync()
        {
            var products = await _service.GetAsync();
            var dtos = _useCase.ToIEnumerableDto(products);
            return ProductResponseView<ProductDto>.Factories.CreateResponseView(dtos);
        }

        public async Task<ProductResponseView<ProductDto>> GetProductsAsync(Guid id)
        {
            var product = await _service.GetAsync(id);
            var dto = _useCase.ToDto(product);
            return ProductResponseView<ProductDto>.Factories.CreateResponseView(new[] { dto });
        }

        public async Task<ProductResponseView<ProductDto>> RegisterProductAsync(CreateProductRequest productRequest)
        {
            var entity = _useCase.ToEntity(productRequest);
            entity = await _service.RegisterAsync(entity);
            var dto = _useCase.ToDto(entity);
            return ProductResponseView<ProductDto>.Factories.CreateResponseView(new[] { dto });
        }

        public async Task<ProductResponseView<ProductDto>> UpdateProductAsync(UpdateProductRequest productRequest)
        {
            var entity = _useCase.ToEntity(productRequest);
            entity = await _service.UpdateAsync(entity);
            var dto = _useCase.ToDto(entity);
            return ProductResponseView<ProductDto>.Factories.CreateResponseView(new[] {dto});
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _service.DeleteAsync(id);
        }
    }
}
