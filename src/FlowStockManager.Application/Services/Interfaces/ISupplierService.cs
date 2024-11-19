using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Application.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<Supplier> GetAsync(Guid supplierId);
    }
}
