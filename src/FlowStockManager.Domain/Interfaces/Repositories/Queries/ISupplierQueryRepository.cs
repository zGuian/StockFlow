using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Repositories.Queries
{
    public interface ISupplierQueryRepository : IBaseQueryRepository<Supplier, Guid>
    {
        Task<IEnumerable<Supplier>> FindDataBaseAsync(int skip, int take);
        Task<bool> HasRegistered(string id);
    }
}
