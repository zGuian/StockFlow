using FlowStockManager.Domain.Responses.SupplierResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Suppliers;

namespace FlowStockManager.Application.SupplierApp.Interfaces
{
    public interface IGetSuppliersPageableQuery
    {
        Task<SupplierResponseView<SupplierDto>> ExecuteAsync(int skip, int take);
    }
}
