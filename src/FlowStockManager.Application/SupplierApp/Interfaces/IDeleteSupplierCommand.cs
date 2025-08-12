
namespace FlowStockManager.Application.SupplierApp.Interfaces
{
    public interface IDeleteSupplierCommand
    {
        Task ExecuteAsync(Guid id);
    }
}
