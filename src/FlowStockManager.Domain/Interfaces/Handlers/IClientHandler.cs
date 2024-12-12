using FlowStockManager.Domain.DTOs.Clients;
using FlowStockManager.Domain.Requests.ClientRequest;
using FlowStockManager.Domain.Responses.ClientResponse;

namespace FlowStockManager.Domain.Interfaces.Handlers
{
    public interface IClientHandler
    {
        Task<ClientResponseView> GetAsync(int take, int skip);
        Task<ClientResponseView> GetAsync(Guid id);
        Task<ClientResponseView> RegisterAsync(CreateClientRequest clientRequest);
        Task<ClientResponseView> UpdateAsync(UpdateClientRequest clientRequest);
        Task DeleteAsync(Guid id);
    }
}
