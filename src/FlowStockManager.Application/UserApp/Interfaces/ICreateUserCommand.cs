using FlowStockManager.Domain.Requests.UserRequests;

namespace FlowStockManager.Application.UserApp.Interfaces
{
    public interface ICreateUserCommand
    {
        Task<bool> ExecuteAsync(CreateUserRequest userRequest);
    }
}
