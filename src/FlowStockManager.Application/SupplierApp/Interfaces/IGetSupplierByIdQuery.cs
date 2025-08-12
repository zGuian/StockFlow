using FlowStockManager.Domain.Responses.SupplierResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Suppliers;

namespace FlowStockManager.Application.SupplierApp.Interfaces
{
    public interface IGetSupplierByIdQuery
    {
        Task<SupplierResponseView<SupplierDto>> ExecuteAsync(Guid id);
    }
}
