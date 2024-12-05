using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.ClientRequest;
using FlowStockManager.Infra.CrossCutting.DTOs.Clients;

namespace FlowStockManager.Application.UseCases.Interfaces
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
