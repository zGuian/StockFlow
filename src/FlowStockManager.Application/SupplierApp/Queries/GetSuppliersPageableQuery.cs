using FlowStockManager.Application.Converters.Interfaces;
using FlowStockManager.Application.SupplierApp.Interfaces;
using FlowStockManager.Domain.Interfaces.Repositories.Queries;
using FlowStockManager.Domain.Responses.SupplierResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Suppliers;

namespace FlowStockManager.Application.SupplierApp.Queries
{
    public sealed class GetSuppliersPageableQuery : IGetSuppliersPageableQuery
    {
        private readonly ISupplierQueryRepository _repository;
        private readonly ISupplierConverter _supplierConverter;

        public GetSuppliersPageableQuery(ISupplierQueryRepository repository, ISupplierConverter supplierConverter)
        {
            _repository = repository;
            _supplierConverter = supplierConverter;
        }

        public async Task<SupplierResponseView<SupplierDto>> ExecuteAsync(int skip, int take)
        {
            return SupplierResponseView<SupplierDto>.Factories.
                CreateResponseView(_supplierConverter.ToEnumerableDto(await _repository.FindDataBaseAsync(skip, take)));
        }
    }
}
