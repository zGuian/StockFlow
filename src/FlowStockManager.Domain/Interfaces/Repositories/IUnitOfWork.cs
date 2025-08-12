
namespace FlowStockManager.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}
