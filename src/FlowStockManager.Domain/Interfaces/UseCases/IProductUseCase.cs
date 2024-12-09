using FlowStockManager.Domain.DTOs.Products;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.OrderRequest.DtoRequest;
using FlowStockManager.Domain.Requests.ProductRequests;

namespace FlowStockManager.Domain.Interfaces.UseCases
{
    public interface IProductUseCase
    {
        IEnumerable<ProductDto> EnumerableToDto(IEnumerable<Product> products);
        IEnumerable<Product> EnumerableToEntity(IEnumerable<ProductDtoRequest> products);
        ProductDto ToDto(Product product);
        Product CreateProduct(CreateProductRequest productRequest, Guid supplierId);
        Product ToEntity(UpdateProductRequest productRequest);
    }
}
