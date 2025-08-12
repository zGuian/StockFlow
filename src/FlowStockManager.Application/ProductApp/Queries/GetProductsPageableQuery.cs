using FlowStockManager.Application.Converters.Interfaces;
using FlowStockManager.Application.ProductApp.Interfaces;
using FlowStockManager.Domain.Interfaces.Repositories.Queries;
using FlowStockManager.Domain.Responses.ProductResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;

namespace FlowStockManager.Application.ProductApp.Queries
{
    public sealed class GetProductsPageableQuery : IGetProductsPageableQuery
    {
        private readonly IProductQueryRepository _repository;
        private readonly IProductConverter _productConverter;

        public GetProductsPageableQuery(IProductQueryRepository repository, IProductConverter productUseCase)
        {
            _repository = repository;
            _productConverter = productUseCase;
        }

        public async Task<ProductResponseView<ProductDto>> ExecuteAsync(int take, int skip)
        {
            var products = await _repository.FindDataBaseAsync(take, skip);
            var dtos = _productConverter.ToIEnumerableDto(products);
            return ProductResponseView<ProductDto>.Factories.CreateResponseView(dtos);
        }
    }
}
