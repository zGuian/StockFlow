using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Application.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetAsync(int skip, int take);
        Task<Supplier> GetAsync(Guid supplierId);
        Task<Supplier> RegisterAsync(Supplier supplier);
        Task<Supplier> UpdateAsync(Supplier supplier);
        Task DeleteAsync(Guid id);
    }
}
