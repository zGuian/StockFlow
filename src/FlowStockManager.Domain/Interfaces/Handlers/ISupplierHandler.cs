using FlowStockManager.Domain.DTOs.Suppliers;
using FlowStockManager.Domain.Requests.SupplierRequests;
using FlowStockManager.Domain.Responses.SupplierResponse;

namespace FlowStockManager.Domain.Interfaces.Handlers
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
