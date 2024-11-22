using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.SupplierRequests;
using FlowStockManager.Infra.CrossCutting.DTOs.Suppliers;

namespace FlowStockManager.Application.UseCases.Interfaces
{
    public interface ISupplierUseCase
    {
        Supplier CreateSupplier(CreateSupplierRequest supplierRequest);
        SupplierDto ToDto(Supplier supplier);
        Supplier ToEntity(UpdateSupplierRequest supplierRequest);
        IEnumerable<SupplierDto> ToEnumerableDto(IEnumerable<Supplier> suppliers);
    }
}
