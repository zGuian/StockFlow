using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Services
{
    public interface IClientService
    {
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Client>> GetAsync(int take, int skip);
        Task<Client> GetAsync(Guid id);
        Task<Client> RegisterAsync(Client entity);
        Task<Client> UpdateAsync(Client entity);
    }
}
