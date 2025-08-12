namespace FlowStockManager.Domain.Interfaces.Repositories.Queries
{
    public interface IBaseQueryRepository<TEntity, UId>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(UId id);
    }
}
