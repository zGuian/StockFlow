using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Domain.Responses.ProductResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;

namespace FlowStockManager.Application.Handlers.Interfaces
{
    public interface IProductHandler
    {
        Task<ProductResponseView<ProductDto>> GetProductsAsync(int take, int skip);
        Task<ProductResponseView<ProductDto>> GetProductsAsync(Guid id);
        Task<ProductResponseView<ProductDto>> RegisterProductAsync(CreateProductRequest productRequest);
        Task<ProductResponseView<ProductDto>> UpdateProductAsync(UpdateProductRequest productRequest);
        Task DeleteProductAsync(Guid id);
    }
}
