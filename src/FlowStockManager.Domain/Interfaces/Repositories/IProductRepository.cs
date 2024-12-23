using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> FindDataBaseAsync(IEnumerable<Guid> productIds);
        Task UpdateDataBaseAsync(IEnumerable<Product> products);
        Task<bool> VerifyQuantityInDataBaseAsync(List<Guid> productsIds);
        bool VerifyDataBaseDisponibleProduct(List<Guid> productsId);
    }
}
