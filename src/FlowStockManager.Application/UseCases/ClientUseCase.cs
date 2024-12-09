using AutoMapper;
using FlowStockManager.Domain.DTOs.Clients;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.UseCases;
using FlowStockManager.Domain.Requests.ClientRequest;

namespace FlowStockManager.Application.UseCases
{
    public class ClientUseCase : IClientUseCase
    {
        private readonly IMapper _mapper;

        public ClientUseCase(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<ClientDto> EnumerableToDto(IEnumerable<Client> clients)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ClientDto> EnumerableToEntity(IEnumerable<Client> clients)
        {
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
        }

        public IEnumerable<Client> EnumerableToEntity(IEnumerable<ClientDto> clientsDtos)
        {
            throw new NotImplementedException();
        }

        public ClientDto ToDto(Client client)
        {
            throw new NotImplementedException();
        }

        public Client ToEntity(ClientDto clientDto)
        {
            throw new NotImplementedException();
        }

        public Client ToEntity(UpdateClientRequest clientDto)
        {
            throw new NotImplementedException();
        }

        public Client ToEntity(CreateClientRequest clientDto)
        {
            throw new NotImplementedException();
        }
    }
}
