using AutoMapper;
using FlowStockManager.Domain.DTOs.Clients;
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
                    opts => opts.MapFrom(dest => dest.ClientId));

            CreateMap<Client, ClientDto>()
                .ForMember(src => src.Orders, opts => opts.MapFrom(dest => dest.Orders));

            CreateMap<ClientDto, Client>()
                .ForMember(src => src.Orders, opts => opts.MapFrom(dest => dest.Orders));
        }
    }
}
