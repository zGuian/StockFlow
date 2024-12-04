using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Application.Services.Interfaces
{
    public interface IClientService
    {
        Task<Client> GetAsync(Guid id);
    }
}
