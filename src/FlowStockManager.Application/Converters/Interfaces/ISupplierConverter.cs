using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.SupplierRequests;
using FlowStockManager.Infra.CrossCutting.DTOs.Suppliers;

namespace FlowStockManager.Application.Converters.Interfaces
{
    public interface ISupplierConverter
    {
        Supplier CreateSupplier(CreateSupplierRequest supplierRequest);
        SupplierDto ToDto(Supplier supplier);
        Supplier ToEntity(UpdateSupplierRequest supplierRequest);
        IEnumerable<SupplierDto> ToEnumerableDto(IEnumerable<Supplier> suppliers);
    }
}
