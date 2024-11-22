using AutoMapper;
using FlowStockManager.Application.UseCases.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.SupplierRequests;
using FlowStockManager.Infra.CrossCutting.DTOs.Suppliers;

namespace FlowStockManager.Application.UseCases
{
    public class SupplierUseCase : ISupplierUseCase
    {
        private readonly IMapper _mapper;

        public SupplierUseCase(IMapper mapper)
        {
            _mapper = mapper;
        }

        public SupplierDto ToDto(Supplier supplier)
        {
            return _mapper.Map<SupplierDto>(supplier);
        }

        public Supplier CreateSupplier(CreateSupplierRequest supplierRequest)
        {
            return Supplier.Factories.NewSupplier(supplierRequest.Name, supplierRequest.Contact, 
                supplierRequest.Address);
        }

        public Supplier ToEntity(UpdateSupplierRequest supplierRequest)
        {
            return _mapper.Map<Supplier>(supplierRequest);
        }

        public IEnumerable<SupplierDto> ToEnumerableDto(IEnumerable<Supplier> suppliers)
        {
            return _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
        }
    }
}
