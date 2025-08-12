using FlowStockManager.Application.SupplierApp.Interfaces;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Repositories.Commands;

namespace FlowStockManager.Application.SupplierApp.Command
{
    public sealed class DeleteSupplierCommand : IDeleteSupplierCommand
    {
        private readonly ISupplierCommandRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSupplierCommand(ISupplierCommandRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }
    }
}
