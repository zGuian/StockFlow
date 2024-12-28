using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> FindDataBaseAsync(IEnumerable<Guid> productIds);
        Task UpdateDataBaseAsync(IEnumerable<Product> products);
        Task UpdateDataBaseAsync(IEnumerable<Tuple<Product, int>> tuple);
        Task<bool> VerifyQuantityInDataBaseAsync(List<Guid> productsIds);
        bool VerifyDataBaseDisponibleProduct(List<Guid> productsId);
        Task<IEnumerable<Tuple<Product, int>>> VerifyDataBaseDisponibleProduct(Dictionary<Guid, int> dictionary);
        Task<IEnumerable<Tuple<Product, int>>> FindDataBaseAsync(Dictionary<Guid, int> dict);
    }
}
