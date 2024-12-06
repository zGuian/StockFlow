using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Base
{
    public interface ICrudBase<T> where T : class
    {
        Task<Pageable<T>> FindDataBaseAsync(int take, int skip);
        Task<T> FindDataBaseAsync(Guid id);
        Task<T> RegisterDataBaseAsync(T entity);
        Task<T> UpdateDataBaseAsync(T entity);
        Task DeleteDataBaseAsync(Guid id);
    }
}
