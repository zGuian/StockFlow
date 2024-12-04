using AutoMapper;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.OrderRequest;

namespace FlowStockManager.Infra.CrossCutting.Profiles
{
    public class ClientMapper : Profile
    {
        public ClientMapper()
        {
            CreateMap<CreateOrderRequest, Client>()
                .ForMember(src => src.Id,
                    opts =>
                    opts.MapFrom(dest => dest.ClientId));
        }
    }
}
