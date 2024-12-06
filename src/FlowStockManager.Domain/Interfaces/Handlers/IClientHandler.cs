using FlowStockManager.Domain.DTOs.Clients;
using FlowStockManager.Domain.Requests.ClientRequest;
using FlowStockManager.Domain.Responses.ClientResponse;

namespace FlowStockManager.Domain.Interfaces.Handlers
{
    public interface IClientHandler
    {
        Task<ClientResponseView<ClientDto>> GetAsync(int take, int skip);
        Task<ClientResponseView<ClientDto>> GetAsync(Guid id);
        Task<ClientResponseView<ClientDto>> RegisterAsync(CreateClientRequest clientRequest);
        Task<ClientResponseView<ClientDto>> UpdateAsync(UpdateClientRequest clientRequest);
        Task DeleteAsync(Guid id);
    }
}
