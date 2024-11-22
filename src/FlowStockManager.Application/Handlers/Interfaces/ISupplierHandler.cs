using FlowStockManager.Domain.Requests.SupplierRequests;
using FlowStockManager.Domain.Responses.SupplierResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Suppliers;

namespace FlowStockManager.Application.Handlers.Interfaces
{
    public interface ISupplierHandler
    {
        Task<SupplierResponseView<SupplierDto>> GetSuppliersAsync(int skip, int take);
        Task<SupplierResponseView<SupplierDto>> GetSuppliersAsync(Guid id);
        Task<SupplierResponseView<SupplierDto>> RegisterSupplierAsync(CreateSupplierRequest supplierRequest);
        Task<SupplierResponseView<SupplierDto>> UpdateSupplierAsync(UpdateSupplierRequest supplierRequest);
        Task DeleteSupplier(Guid id);
    }
}
