using FlowStockManager.Application.UseCases.Interfaces;
using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Application.Services
{
    public class ProductService : IProductService
    {
        public Task<IEnumerable<Product>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> RegisterAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
