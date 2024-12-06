using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task DeleteDataBaseAsync(Guid id);
        Task<IEnumerable<Client>> FindDataBaseAsync(int take, int skip);
        Task<Client> FindDataBaseAsync(Guid id);
        Task<Client> RegisterDataBaseAsync(Client entity);
        Task<Client> UpdateDataBaseAsync(Client entity);
    }
}
