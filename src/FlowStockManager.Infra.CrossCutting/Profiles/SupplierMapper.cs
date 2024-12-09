using AutoMapper;
using FlowStockManager.Domain.DTOs.Suppliers;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.SupplierRequests;

namespace FlowStockManager.Infra.CrossCutting.Profiles
{
    public class SupplierMapper : Profile
    {
        public SupplierMapper()
        {
            CreateMap<Supplier, CreateSupplierRequest>()
                .ReverseMap();

            CreateMap<Supplier, SupplierDto>()
                .ReverseMap();

            CreateMap<Supplier, UpdateSupplierRequest>()
                .ReverseMap();
        }
    }
}
