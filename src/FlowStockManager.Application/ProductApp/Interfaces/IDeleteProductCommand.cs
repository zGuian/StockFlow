
namespace FlowStockManager.Application.ProductApp.Interfaces
{
    public interface IDeleteProductCommand
    {
        Task ExecuteAsync(Guid id);
    }
}
