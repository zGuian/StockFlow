using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task DeleteInDataBaseAsync(Guid id);
        Task<IEnumerable<Product>> FindDataBaseAsync(int take, int skip);
        Task<Product> FindDataBaseAsync(Guid id);
        Task<Product> RegisterDataBaseAsync(Product product);
        Task<Product> UpdateDataBaseAsync(Product product);
        Task<bool> VerifyQuantityInDataBaseAsync(List<Guid> productsIds);
        bool VerifyDataBaseDisponibleProduct(List<Guid> productsId);
    }
}
