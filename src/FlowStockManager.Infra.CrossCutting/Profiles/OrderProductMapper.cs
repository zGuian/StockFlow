using AutoMapper;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.OrderRequest;

namespace FlowStockManager.Infra.CrossCutting.Profiles
{
    public class OrderProductMapper : Profile
    {
        public OrderProductMapper()
        {
            CreateMap<OrderProduct, Order>()
                .ForMember(src => src.OrderProducts, opts =>
                    opts.MapFrom(dest => dest.Orders))
                .ReverseMap();

            CreateMap<OrderProduct, Product>()
                .ForMember(src => src.OrderProducts, opts =>
                    opts.MapFrom(dest => dest.Product))
                .ReverseMap();

            CreateMap<CreateOrderRequest, OrderProduct>()
                .ForMember(src => src.Product, opts =>
                    opts.MapFrom(dest => dest.Products));
        }
    }
}
