using FlowStockManager.Application.Converters.Interfaces;
using FlowStockManager.Application.UserApp.Interfaces;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Repositories.Commands;
using FlowStockManager.Domain.Requests.UserRequests;

namespace FlowStockManager.Application.UserApp.Command
{
    public sealed class CreateUserCommand : ICreateUserCommand
    {
        private readonly IUserCommandRepository _commandRepository;
        private readonly IUserConverter _converter;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommand(IUserCommandRepository commandRepository, IUserConverter converter, IUnitOfWork unitOfWork)
        {
            _commandRepository = commandRepository;
            _converter = converter;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecuteAsync(CreateUserRequest userRequest)
        {
            ValidateInput(userRequest);
            var user = _converter.CreateUser(userRequest);
            await _commandRepository.RegisterAsync(user);
            await _unitOfWork.CommitAsync();
            await Task.Delay(TimeSpan.FromSeconds(3));
        }

        private void ValidateInput(CreateUserRequest input)
        {
            throw new NotImplementedException();
        }
    }
}
