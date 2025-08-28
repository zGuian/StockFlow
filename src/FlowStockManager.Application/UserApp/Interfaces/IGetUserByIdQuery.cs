using FlowStockManager.Infra.CrossCutting.DTOs.Users;

namespace FlowStockManager.Application.UserApp.Interfaces
{
    public interface IGetUserByIdQuery
    {
        Task<UserDto> ExecuteAsync(string id);
    }
}
