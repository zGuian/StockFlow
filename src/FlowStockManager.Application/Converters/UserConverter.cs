using AutoMapper;
using FlowStockManager.Application.Converters.Interfaces;
using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Requests.UserRequests;
using FlowStockManager.Infra.CrossCutting.DTOs.Users;

namespace FlowStockManager.Application.Converters
{
    public class UserConverter : IUserConverter
    {
        private readonly IMapper _mapper;

        public UserConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserDto ToDto(User product)
        {
            return _mapper.Map<UserDto>(product);
        }

        public User ToEntity(UpdateUserRequest userRequest)
        {
            return _mapper.Map<User>(userRequest);
        }

        public IEnumerable<UserDto> ToIEnumerableDto(IEnumerable<Product> products)
        {
            return _mapper.Map<IEnumerable<UserDto>>(products);
        }

        public User CreateUser(CreateUserRequest userRequest)
        {
            return User.Factories.Create(userRequest.FirstName, userRequest.LastName, userRequest.Email, userRequest.Password);
        }
    }
}
