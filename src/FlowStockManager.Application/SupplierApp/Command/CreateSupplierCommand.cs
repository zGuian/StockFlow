using FlowStockManager.Application.Converters.Interfaces;
using FlowStockManager.Application.SupplierApp.Interfaces;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Repositories.Commands;
using FlowStockManager.Domain.Requests.SupplierRequests;
using FlowStockManager.Domain.Responses.SupplierResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Suppliers;

namespace FlowStockManager.Application.SupplierApp.Command
{
    public sealed class CreateSupplierCommand : ICreateSupplierCommand
    {
        private readonly ISupplierCommandRepository _repository;
        private readonly ISupplierConverter _supplierConverter;
        private readonly IUnitOfWork _unitOfWork;

        public CreateSupplierCommand(ISupplierCommandRepository repository, ISupplierConverter supplierUseCase, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _supplierConverter = supplierUseCase;
            _unitOfWork = unitOfWork;
        }


        public async Task<SupplierResponseView<SupplierDto>> ExecuteAsync(CreateSupplierRequest supplierRequest)
        {
            var entity = _supplierConverter.CreateSupplier(supplierRequest);
            await _repository.RegisterAsync(entity);
            await _unitOfWork.CommitAsync();
            var dto = _supplierConverter.ToDto(entity);
            return SupplierResponseView<SupplierDto>.Factories.CreateResponseView([dto]);
        }
    }
}
