using FlowStockManager.Domain.DTOs.Clients;
using FlowStockManager.Domain.Requests.ClientRequest;
using FlowStockManager.Domain.Responses.Base;
using FlowStockManager.Domain.Responses.ClientResponse;

namespace FlowStockManager.Domain.Interfaces.Handlers
{
    public interface IClientHandler
    {
        Task<ResponsePage<IEnumerable<ClientDto>>> GetAsync(int take, int skip);
        Task<Response<ClientDto>> GetAsync(Guid id);
        Task<Response<ClientDto>> RegisterAsync(CreateClientRequest clientRequest);
        Task<Response<ClientDto>> UpdateAsync(UpdateClientRequest clientRequest);
        Task DeleteAsync(Guid id);
    }
}
