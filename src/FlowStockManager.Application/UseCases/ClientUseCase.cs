using AutoMapper;
using FlowStockManager.Application.UseCases.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Infra.CrossCutting.DTOs.Clients;

namespace FlowStockManager.Application.UseCases
{
    public class ClientUseCase : IClientUseCase
    {
        private readonly IMapper _mapper;

        public ClientUseCase(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<ClientDto> EnumerableToEntity(IEnumerable<Client> clients)
        {
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
        }
    }
}
