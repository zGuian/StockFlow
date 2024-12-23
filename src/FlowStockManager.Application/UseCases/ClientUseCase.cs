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
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
        }

        public IEnumerable<ClientDto> EnumerableToEntity(IEnumerable<Client> clients)
        {
            return _mapper.Map<IEnumerable<ClientDto>>(clients);
        }

        public IEnumerable<Client> EnumerableToEntity(IEnumerable<ClientDto> clientsDtos)
        {
            return _mapper.Map<IEnumerable<Client>>(clientsDtos);
        }

        public ClientDto ToDto(Client client)
        {
            return _mapper.Map<ClientDto>(client);
        }

        public Client ToEntity(ClientDto clientDto)
        {
            return ConvertInEntity(clientDto);
        }

        public Client ToEntity(UpdateClientRequest clientDto)
        {
            return ConvertInEntity(clientDto);
        }

        public Client ToEntity(CreateClientRequest clientDto)
        {
            return ConvertInEntity(clientDto);
        }

        private Client ConvertInEntity<T>(T dto)
        {
            return _mapper.Map<Client>(dto);
        }
    }
}
