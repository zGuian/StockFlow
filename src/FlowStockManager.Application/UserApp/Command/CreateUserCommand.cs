using FlowStockManager.Application.UserApp.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Responses.ProductResponse;

namespace FlowStockManager.Application.UserApp.Command
{
    public sealed class CreateUserCommand : ICreateUserCommand
    {
        public async Task<ProductResponseView<User>> ExecuteAsync(User userRequest)
        {
            throw new NotImplementedException();
        }
    }
}
