using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Repositories.Queries
{
    public interface IProductQueryRepository : IBaseQueryRepository<Product, string>
    {
        Task<IEnumerable<Product>> FindDataBaseAsync(int take, int skip);
        Task<Product[]> FindProductsAsync(Dictionary<string, int> values);
    }
}
