using FlowStockManager.Application.ProductApp.Interfaces;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Repositories.Commands;

namespace FlowStockManager.Application.ProductApp.Command
{
    public sealed class DeleteProductCommand : IDeleteProductCommand
    {
        private readonly IProductCommandRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommand(IProductCommandRepository repository, IUnitOfWork unitOfWork)
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
