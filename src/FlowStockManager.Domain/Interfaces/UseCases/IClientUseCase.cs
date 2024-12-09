using FlowStockManager.Domain.DTOs.Clients;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.ClientRequest;

namespace FlowStockManager.Domain.Interfaces.UseCases
{
    public interface IClientUseCase
    {
        IEnumerable<ClientDto> EnumerableToDto(IEnumerable<Client> clients);
        IEnumerable<Client> EnumerableToEntity(IEnumerable<ClientDto> clientsDtos);
        ClientDto ToDto(Client client);
        Client ToEntity(ClientDto clientDto);
        Client ToEntity(UpdateClientRequest clientDto);
        Client ToEntity(CreateClientRequest clientDto);
    }
}
