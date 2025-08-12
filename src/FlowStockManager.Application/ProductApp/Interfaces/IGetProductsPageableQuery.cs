using FlowStockManager.Domain.Responses.ProductResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;

namespace FlowStockManager.Application.ProductApp.Interfaces
{
    public interface IGetProductsPageableQuery
    {
        Task<ProductResponseView<ProductDto>> ExecuteAsync(int take, int skip);
    }
}
