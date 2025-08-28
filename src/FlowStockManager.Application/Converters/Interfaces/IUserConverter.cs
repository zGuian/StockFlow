using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.UserRequests;
using FlowStockManager.Infra.CrossCutting.DTOs.Users;

namespace FlowStockManager.Application.Converters.Interfaces
{
    public interface IUserConverter
    {
        User CreateUser(CreateUserRequest userRequest);
        UserDto ToDto(User product);
        User ToEntity(UpdateUserRequest userRequest);
        IEnumerable<UserDto> ToIEnumerableDto(IEnumerable<Product> products);
    }
}
