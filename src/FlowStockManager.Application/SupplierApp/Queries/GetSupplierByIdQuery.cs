using FlowStockManager.Application.Converters.Interfaces;
using FlowStockManager.Application.SupplierApp.Interfaces;
using FlowStockManager.Domain.Interfaces.Repositories.Queries;
using FlowStockManager.Domain.Responses.SupplierResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Suppliers;

namespace FlowStockManager.Application.SupplierApp.Queries
{
    public class GetSupplierByIdQuery : IGetSupplierByIdQuery
    {
        private readonly ISupplierQueryRepository _repository;
        private readonly ISupplierConverter _supplierConverter;

        public GetSupplierByIdQuery(ISupplierQueryRepository repository, ISupplierConverter supplierConverter)
        {
            _repository = repository;
            _supplierConverter = supplierConverter;
        }

        public async Task<SupplierResponseView<SupplierDto>> ExecuteAsync(Guid id)
        {
            var dto = _supplierConverter.ToDto(await _repository.GetByIdAsync(id));
            return SupplierResponseView<SupplierDto>.Factories.
                CreateResponseView([dto]);
        }
    }
}
