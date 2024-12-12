using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Services;

namespace FlowStockManager.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService(ISupplierRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Supplier>> GetAsync(int skip, int take)
        {
            return await _repository.FindDataBaseAsync(skip, take);
        }

        public async Task<Supplier> GetAsync(Guid supplierId)
        {
            return await _repository.FindDataBaseAsync(s => s.Id == supplierId);
        }

        public async Task<Supplier> RegisterAsync(Supplier supplier)
        {
            return await _repository.RegisterDataBaseAsync(supplier);
        }

        public async Task<Supplier> UpdateAsync(Supplier supplier)
        {
            return await _repository.UpdateDataBaseAsync(supplier);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(s => s.Id == id);
        }
    }
}
