using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Domain.Responses.ProductResponse;

namespace FlowStockManager.Domain.Interfaces.Handlers
{
    public interface IProductHandler
    {
        Task<ProductResponseView> GetProductsAsync(int take, int skip);
        Task<ProductResponseView> GetProductsAsync(Guid id);
        Task<ProductResponseView> RegisterProductAsync(CreateProductRequest productRequest);
        Task<ProductResponseView> UpdateProductAsync(UpdateProductRequest productRequest);
        Task DeleteProductAsync(Guid id);
    }
}
