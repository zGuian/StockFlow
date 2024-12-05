using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task DeleteInDataBaseAsync(Guid id);
        Task<IEnumerable<Product>> FindDataBaseAsync(int take, int skip);
        Task<IEnumerable<Product>> FindDataBaseAsync(IEnumerable<Guid> productIds);
        Task<Product> FindDataBaseAsync(Guid id);
        Task<Product> RegisterDataBaseAsync(Product product);
        Task<Product> UpdateDataBaseAsync(Product product);
        Task UpdateDataBaseAsync(IEnumerable<Product> products);
        Task<bool> VerifyQuantityInDataBaseAsync(List<Guid> productsIds);
        bool VerifyDataBaseDisponibleProduct(List<Guid> productsId);
    }
}
