using AutoMapper;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.OrderRequest;
using FlowStockManager.Infra.CrossCutting.DTOs.Orders;

namespace FlowStockManager.Infra.CrossCutting.Profiles
{
    public class OrderMapper : Profile
    {
        public OrderMapper()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(src => src.Products, opts =>
                    opts.MapFrom(dest => dest.OrderProducts.Select(p => p.Product)));
        }
    }
}
