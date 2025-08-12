namespace FlowStockManager.Domain.Interfaces.Repositories.Commands
{
    public interface IBaseCommandRepository<TEntity, UId> where TEntity : class
    {
        Task DeleteAsync(UId id);
        Task RegisterAsync(TEntity obj);
        void Update(TEntity obj);
    }
}
