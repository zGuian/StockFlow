using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;

namespace FlowStockManager.Application.Services.Interfaces
{
    public interface IProductUseCase
    {
        IEnumerable<ProductDto> ToIEnumerableDto(IEnumerable<Product> products);
        ProductDto ToDto(Product product);
        Product ToEntity(CreateProductRequest productRequest);
        Product ToEntity(UpdateProductRequest productRequest);
    }
}
