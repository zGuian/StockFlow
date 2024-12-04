using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> FindDataBaseAsync(Guid id);
    }
}
