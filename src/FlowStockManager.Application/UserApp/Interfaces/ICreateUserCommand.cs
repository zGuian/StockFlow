using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Responses.ProductResponse;

namespace FlowStockManager.Application.UserApp.Interfaces
{
    public interface ICreateUserCommand
    {
        Task<ProductResponseView<User>> ExecuteAsync(User userRequest);
    }
}
