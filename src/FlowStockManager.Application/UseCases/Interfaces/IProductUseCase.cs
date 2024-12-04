using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.OrderRequest.DtoRequest;
using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;

namespace FlowStockManager.Application.UseCases.Interfaces
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
