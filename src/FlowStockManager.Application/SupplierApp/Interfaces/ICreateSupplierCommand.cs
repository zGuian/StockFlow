using FlowStockManager.Domain.Requests.SupplierRequests;
using FlowStockManager.Domain.Responses.SupplierResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Suppliers;

namespace FlowStockManager.Application.SupplierApp.Interfaces
{
    public interface ICreateSupplierCommand
    {
        Task<SupplierResponseView<SupplierDto>> ExecuteAsync(CreateSupplierRequest supplierRequest);
    }
}
