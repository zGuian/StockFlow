
namespace FlowStockManager.Application.UserApp.Interfaces
{
    public interface IDisableUserCommand
    {
        Task<bool> ExecuteAsync(string request);
    }
}
