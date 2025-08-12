using FlowStockManager.Application.Converters.Interfaces;
using FlowStockManager.Application.ProductApp.Interfaces;
using FlowStockManager.Domain.Interfaces.Repositories.Queries;
using FlowStockManager.Domain.Responses.ProductResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;

namespace FlowStockManager.Application.ProductApp.Queries
{
    public class GetProductByIdQuery : IGetProductByIdQuery
    {
        private readonly IProductQueryRepository _repository;
        private readonly IProductConverter _productConverter;

        public GetProductByIdQuery(IProductQueryRepository repository, IProductConverter productUseCase)
        {
            _repository = repository;
            _productConverter = productUseCase;
        }
        public async Task<ProductResponseView<ProductDto>> ExecuteAsync(Guid id)
        {
            var product = await _repository.GetByIdAsync(id);
            var dto = _productConverter.ToDto(product);
            return ProductResponseView<ProductDto>.Factories.CreateResponseView([dto]);
        }
    }
}
