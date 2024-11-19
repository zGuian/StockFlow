using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Domain.Responses.ProductResponse;

namespace FlowStockManager.Application.Handlers.Interfaces
{
    public interface IProductHandler
    {
        Task<IEnumerable<ProductResponseView<Product>>> GetProductsAsync();
        Task<ProductResponseView<Product>> GetProductsAsync(Guid id);
        Task<ProductResponseView<Product>> RegisterProductAsync(CreateProductRequest productRequest);
        Task<ProductResponseView<Product>> UpdateProductAsync(UpdateProductRequest productRequest);
        Task DeleteProductAsync(Guid id);
    }
}
