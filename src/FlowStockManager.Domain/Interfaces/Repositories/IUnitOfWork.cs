namespace FlowStockManager.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        ISupplierRepository SupplierRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        IClientRepository ClientRepository { get; }
        IOrderProductRepository OrderProductRepository { get; }
        Task CommitAsync();
    }
}
