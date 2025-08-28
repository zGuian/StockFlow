using AutoMapper;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.UserRequests;
using FlowStockManager.Infra.CrossCutting.DTOs.Users;

namespace FlowStockManager.Infra.CrossCutting.Profiles
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<CreateUserRequest, User>();

            CreateMap<User, UserDto>()
                .ReverseMap();
        }
    }
}
