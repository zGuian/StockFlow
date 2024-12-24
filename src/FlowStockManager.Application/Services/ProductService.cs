using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Services;

namespace FlowStockManager.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAsync(int take, int skip)
        {
            return await _repository.FindDataBaseAsync(take, skip);
        }

        public async Task<IEnumerable<Product>> GetAsync(IEnumerable<Product> products)
        {
            var productsIds = GetProductIds(products);
            return await _repository.FindDataBaseAsync(productsIds);
        }

        public async Task<Product> GetAsync(Guid id)
        {
            return await _repository.FindDataBaseAsync(id);
        }

        public async Task<Product> RegisterAsync(Product product)
        {
            return await _unitOfWork.ProductRepository.RegisterDataBaseAsync(product);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            return await _unitOfWork.ProductRepository.UpdateDataBaseAsync(product);
        }

        public Task DeleteAsync(Guid id)
        {
            return _unitOfWork.ProductRepository.DeleteAsync(id);
        }

        public bool VerifyDisponible(IEnumerable<Product> products)
        {
            var productsIds = GetProductIds(products);
            return _repository.VerifyDataBaseDisponibleProduct(productsIds);
        }

        public void ConsumeProducts(IEnumerable<Product> products)
        {
            _unitOfWork.ProductRepository.UpdateDataBaseAsync(products);
        }

        private static List<Guid> GetProductIds(IEnumerable<Product> products)
        {
            return products.Select(p => p.Id).ToList();
        }
    }
}
