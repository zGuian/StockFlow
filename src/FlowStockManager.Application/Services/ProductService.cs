using FlowStockManager.Application.Services.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces;

namespace FlowStockManager.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAsync(int take, int skip)
        {
            return await _repository.FindDataBaseAsync(take, skip);
        }

        public async Task<Product> GetAsync(Guid id)
        {
            return await _repository.FindDataBaseAsync(id);
        }

        public async Task<Product> RegisterAsync(Product product)
        {
            return await _repository.RegisterDataBaseAsync(product);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            return await _repository.UpdateDataBaseAsync(product);
        }

        public Task DeleteAsync(Guid id)
        {
            return _repository.DeleteInDataBaseAsync(id);
        }
    }
}
