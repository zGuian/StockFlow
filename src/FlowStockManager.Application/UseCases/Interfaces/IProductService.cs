using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Application.UseCases.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAsync();
        Task<Product> GetAsync(Guid id);
        Task<Product> RegisterAsync(Product entity);
        Task<Product> UpdateAsync(Product entity);
        Task DeleteAsync(Guid id);
    }
}
