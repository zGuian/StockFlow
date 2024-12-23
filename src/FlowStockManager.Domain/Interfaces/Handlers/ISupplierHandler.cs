using FlowStockManager.Domain.DTOs.Suppliers;
using FlowStockManager.Domain.Requests.SupplierRequests;
using FlowStockManager.Domain.Responses.Base;

namespace FlowStockManager.Domain.Interfaces.Handlers
{
    public interface ISupplierHandler
    {
        Task<ResponsePage<IEnumerable<SupplierDto>>> GetSuppliersAsync(int skip, int take);
        Task<Response<SupplierDto>> GetSuppliersAsync(Guid id);
        Task<Response<SupplierDto>> RegisterSupplierAsync(CreateSupplierRequest supplierRequest);
        Task<Response<SupplierDto>> UpdateSupplierAsync(UpdateSupplierRequest supplierRequest);
        Task DeleteSupplier(Guid id);
    }
}
