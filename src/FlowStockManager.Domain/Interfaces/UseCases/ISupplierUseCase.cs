using FlowStockManager.Domain.DTOs.Suppliers;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.SupplierRequests;

namespace FlowStockManager.Domain.Interfaces.UseCases
{
    public interface ISupplierUseCase
    {
        Supplier CreateSupplier(CreateSupplierRequest supplierRequest);
        SupplierDto ToDto(Supplier supplier);
        Supplier ToEntity(UpdateSupplierRequest supplierRequest);
        IEnumerable<SupplierDto> ToEnumerableDto(IEnumerable<Supplier> suppliers);
    }
}
