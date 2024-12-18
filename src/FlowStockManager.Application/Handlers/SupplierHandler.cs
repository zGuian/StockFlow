using FlowStockManager.Domain.DTOs.Suppliers;
using FlowStockManager.Domain.Interfaces.Handlers;
using FlowStockManager.Domain.Interfaces.Services;
using FlowStockManager.Domain.Interfaces.UseCases;
using FlowStockManager.Domain.Requests.SupplierRequests;
using FlowStockManager.Domain.Responses.Base;

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

        public async Task<ResponsePage<IEnumerable<SupplierDto>>> GetSuppliersAsync(int skip, int take)
        {
            var supplier = await _service.GetAsync(skip, take);
            var dto = _useCase.ToEnumerableDto(supplier);
            return ResponsePage<IEnumerable<SupplierDto>>.Factories.CreateResponsePaged(dto, dto.Count());
        }

        public async Task<Response<SupplierDto>> GetSuppliersAsync(Guid id)
        {
            var supplier = await _service.GetAsync(id);
            var dto = _useCase.ToDto(supplier);
            return Response<SupplierDto>.Factories.CreateResponse(dto, true);
        }

        public async Task<Response<SupplierDto>> RegisterSupplierAsync(CreateSupplierRequest supplierRequest)
        {
            var entity = _useCase.CreateSupplier(supplierRequest);
            entity = await _service.RegisterAsync(entity);
            var dto = _useCase.ToDto(entity);
            return Response<SupplierDto>.Factories.CreateResponse(dto, true);
        }

        public async Task<Response<SupplierDto>> UpdateSupplierAsync(UpdateSupplierRequest supplierRequest)
        {
            var entity = _useCase.ToEntity(supplierRequest);
            entity = await _service.UpdateAsync(entity);
            var dto = _useCase.ToDto(entity);
            return Response<SupplierDto>.Factories.CreateResponse(dto, true);
        }

        public async Task DeleteSupplier(Guid id)
        {
            await _service.DeleteAsync(id);
        }
    }
}
