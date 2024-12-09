using AutoMapper;
using FlowStockManager.Domain.DTOs.Orders;
using FlowStockManager.Domain.Entities;

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
