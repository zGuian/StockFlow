using System.Linq.Expressions;

namespace FlowStockManager.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        abstract Task<IEnumerable<TEntity>> FindDataBaseAsync(int skip, int take);
        abstract Task<TEntity> FindDataBaseAsync(Expression<Func<TEntity, bool>> predicate);
        abstract Task<TEntity> RegisterDataBaseAsync(TEntity entity);
        abstract Task<TEntity> UpdateDataBaseAsync(TEntity entity);
        abstract Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
