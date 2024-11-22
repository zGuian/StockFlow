using FlowStockManager.Application.Services.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces;

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
            return await _repository.FindDataBaseAsync(supplierId);
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
            await _repository.DeleteAsync(id);
        }
    }
}
