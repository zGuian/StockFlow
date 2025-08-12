using FlowStockManager.Domain.Responses.ProductResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;

namespace FlowStockManager.Application.ProductApp.Interfaces
{
    public interface IGetProductByIdQuery
    {
        Task<ProductResponseView<ProductDto>> ExecuteAsync(Guid id);
    }
}
