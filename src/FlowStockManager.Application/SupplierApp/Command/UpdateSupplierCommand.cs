using FlowStockManager.Application.Converters.Interfaces;
using FlowStockManager.Application.SupplierApp.Interfaces;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Repositories.Commands;
using FlowStockManager.Domain.Requests.SupplierRequests;
using FlowStockManager.Domain.Responses.SupplierResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Suppliers;

namespace FlowStockManager.Application.SupplierApp.Command
{
    public sealed class UpdateSupplierCommand : IUpdateSupplierCommand
    {
        private readonly ISupplierCommandRepository _repository;
        private readonly ISupplierConverter _supplierConverter;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSupplierCommand(ISupplierCommandRepository repository, ISupplierConverter supplierUseCase, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _supplierConverter = supplierUseCase;
            _unitOfWork = unitOfWork;
        }

        public async Task<SupplierResponseView<SupplierDto>> ExecuteAsync(UpdateSupplierRequest supplierRequest)
        {
            var entity = _supplierConverter.ToEntity(supplierRequest);
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            var dto = _supplierConverter.ToDto(entity);
            return SupplierResponseView<SupplierDto>.Factories.CreateResponseView([dto]);
        }
    }
}
