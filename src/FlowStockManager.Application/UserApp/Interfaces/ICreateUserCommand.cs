using FlowStockManager.Domain.Requests.UserRequests;

namespace FlowStockManager.Application.UserApp.Interfaces
{
    public interface ICreateUserCommand
    {
        Task ExecuteAsync(CreateUserRequest userRequest);
    }
}
