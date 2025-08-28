using FlowStockManager.Application.Commons.Interface;
using FlowStockManager.Domain.Requests.UserRequests;

namespace FlowStockManager.Application.UserApp.Interfaces
{
    public interface IUpdateUserCommand
    {
        Task<bool> ExecuteAsync(UpdateUserRequest request);
    }
}
