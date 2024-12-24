using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Services;

namespace FlowStockManager.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISupplierRepository _repository;

        public SupplierService(IUnitOfWork unitOfWork, ISupplierRepository repository)
        {
            _unitOfWork = unitOfWork;
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
            return await _unitOfWork.SupplierRepository.RegisterDataBaseAsync(supplier);
        }

        public async Task<Supplier> UpdateAsync(Supplier supplier)
        {
            return await _unitOfWork.SupplierRepository.UpdateDataBaseAsync(supplier);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.SupplierRepository.DeleteAsync(id);
        }
    }
}
