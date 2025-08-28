using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;

namespace FlowStockManager.Application.Converters.Interfaces
{
    public interface IProductConverter
    {
        IEnumerable<ProductDto> ToIEnumerableDto(IEnumerable<Product> products);
        ProductDto ToDto(Product product);
        Product CreateProduct(CreateProductRequest productRequest, string supplierId);
        Product ToEntity(UpdateProductRequest productRequest);
        Product ToEntity(ConsumeProductRequest productRequest);
    }
}
