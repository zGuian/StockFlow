using FlowStockManager.Domain.Requests.ProductRequests;
using FlowStockManager.Domain.Responses.ProductResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;

namespace FlowStockManager.Application.ProductApp.Interfaces
{
    public interface IConsumeProductCommand
    {
        Task<ProductResponseView<ProductDto>> ExecuteAsync(ConsumeProductRequest[] request);
    }
}
