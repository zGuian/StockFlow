using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task DeleteInDataBase(Guid id);
        Task<IEnumerable<Product>> FindDataBaseAsync(int take, int skip);
        Task<Product> FindDataBaseAsync(Guid id);
        Task<Product> RegisterDataBaseAsync(Product product);
        Task<Product> UpdateDataBaseAsync(Product product);
    }
}
