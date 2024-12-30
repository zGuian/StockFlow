using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAsync(int take, int skip);
        Task<Product> GetAsync(Guid id);
        Task<Product> RegisterAsync(Product entity);
        Task<Product> UpdateAsync(Product entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Tuple<Product, int>>> VerifyDisponibleAndReturnProduct(Dictionary<Guid, int> dictionary);
        Task ConsumeProductsAsync(IEnumerable<Product> products);
        Task ConsumeProductsAsync(IEnumerable<Tuple<Product, int>> tuple);
    }
}
