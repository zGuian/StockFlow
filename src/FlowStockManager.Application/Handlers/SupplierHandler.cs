using FlowStockManager.Domain.DTOs.Suppliers;
using FlowStockManager.Domain.Interfaces.Handlers;
using FlowStockManager.Domain.Interfaces.Services;
using FlowStockManager.Domain.Interfaces.UseCases;
using FlowStockManager.Domain.Requests.SupplierRequests;
using FlowStockManager.Domain.Responses.SupplierResponse;

namespace FlowStockManager.Application.Handlers
{
    public class SupplierHandler : ISupplierHandler
    {
        private readonly ISupplierService _service;
        private readonly ISupplierUseCase _useCase;

        public SupplierHandler(ISupplierService supplierService, ISupplierUseCase useCase)
        {
            _useCase = useCase;
            _service = supplierService;
        }

        public async Task<SupplierResponseView<SupplierDto>> GetSuppliersAsync(int skip, int take)
        {
            return SupplierResponseView<SupplierDto>.Factories.
                CreateResponseView(_useCase.ToEnumerableDto(await _service.GetAsync(skip, take)));
        }

        public async Task<SupplierResponseView<SupplierDto>> GetSuppliersAsync(Guid id)
        {
            var dto = _useCase.ToDto(await _service.GetAsync(id));
            return SupplierResponseView<SupplierDto>.Factories.
                CreateResponseView(new[] { dto });
        }

        public async Task<SupplierResponseView<SupplierDto>> RegisterSupplierAsync(CreateSupplierRequest supplierRequest)
        {
            var entity = _useCase.CreateSupplier(supplierRequest);
            entity = await _service.RegisterAsync(entity);
            var dto = _useCase.ToDto(entity);
            return SupplierResponseView<SupplierDto>.Factories.CreateResponseView(new[] { dto });
        }

        public async Task<SupplierResponseView<SupplierDto>> UpdateSupplierAsync(UpdateSupplierRequest supplierRequest)
        {
            var entity = _useCase.ToEntity(supplierRequest);
            entity = await _service.UpdateAsync(entity);
            var dto = _useCase.ToDto(entity);
            return SupplierResponseView<SupplierDto>.Factories.CreateResponseView(new[] { dto });
        }

        public async Task DeleteSupplier(Guid id)
        {
            await _service.DeleteAsync(id);
        }
    }
}
