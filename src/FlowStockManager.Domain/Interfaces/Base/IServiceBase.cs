using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Base
{
    public interface IServiceBase<T> where T : class
    {
        Task<Pageable<T>> GetAsync(int take, int skip);
        Task<T> GetAsync(Guid id);
        Task<T> RegisterAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
