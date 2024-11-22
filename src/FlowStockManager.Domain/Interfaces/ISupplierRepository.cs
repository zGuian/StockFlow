using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> FindDataBaseAsync(int skip, int take);
        Task<Supplier> FindDataBaseAsync(Guid supplierId);
        Task<Supplier> RegisterDataBaseAsync(Supplier supplier);
        Task<Supplier> UpdateDataBaseAsync(Supplier supplier);
        Task DeleteAsync(Guid id);
    }
}
