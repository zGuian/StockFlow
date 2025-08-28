using FlowStockManager.Application.Converters.Interfaces;
using FlowStockManager.Application.UserApp.Interfaces;
using FlowStockManager.Domain.Interfaces.Repositories.Queries;
using FlowStockManager.Infra.CrossCutting.DTOs.Users;

namespace FlowStockManager.Application.UserApp.Queries
{
    public class GetUserByIdQuery : IGetUserByIdQuery
    {
        private readonly IUserQueryRepository _userQuery;
        private readonly IUserConverter _converter;

        public GetUserByIdQuery(IUserQueryRepository userQuery, IUserConverter converter)
        {
            _userQuery = userQuery;
            _converter = converter;
        }

        public async Task<UserDto> ExecuteAsync(string id)
        {
            var user = await _userQuery.GetByIdAsync(id);
            var dto = _converter.ToDto(user);
            return dto;
        }
    }
}
