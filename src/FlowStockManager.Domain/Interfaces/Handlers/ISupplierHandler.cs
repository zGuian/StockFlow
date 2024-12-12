using FlowStockManager.Domain.Requests.SupplierRequests;
using FlowStockManager.Domain.Responses.SupplierResponse;

namespace FlowStockManager.Domain.Interfaces.Handlers
{
    public interface ISupplierHandler
    {
        Task<SupplierResponseView> GetSuppliersAsync(int skip, int take);
        Task<SupplierResponseView> GetSuppliersAsync(Guid id);
        Task<SupplierResponseView> RegisterSupplierAsync(CreateSupplierRequest supplierRequest);
        Task<SupplierResponseView> UpdateSupplierAsync(UpdateSupplierRequest supplierRequest);
        Task DeleteSupplier(Guid id);
    }
}
