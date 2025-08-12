using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Repositories.Queries
{
    public interface IProductQueryRepository : IBaseQueryRepository<Product, Guid>
    {
        Task<IEnumerable<Product>> FindDataBaseAsync(int take, int skip);
    }
}
