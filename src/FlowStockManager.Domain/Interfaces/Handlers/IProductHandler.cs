using FlowStockManager.Domain.DTOs.Clients;
using FlowStockManager.Domain.DTOs.Products;
using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Domain.Responses.Base;

namespace FlowStockManager.Domain.Interfaces.Handlers
{
    public interface IProductHandler
    {
        Task<ResponsePage<IEnumerable<ProductDto>>> GetProductsAsync(int take, int skip);
        Task<Response<ProductDto>> GetProductsAsync(Guid id);
        Task<Response<ProductDto>> RegisterProductAsync(CreateProductRequest productRequest);
        Task<Response<ProductDto>> UpdateProductAsync(UpdateProductRequest productRequest);
        Task DeleteProductAsync(Guid id);
    }
}
