using FlowStockManager.Application.Commons.Interface;
using FlowStockManager.Application.Converters.Interfaces;
using FlowStockManager.Application.UserApp.Interfaces;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Repositories.Commands;
using FlowStockManager.Domain.Requests.UserRequests;

namespace FlowStockManager.Application.UserApp.Command
{
    public sealed class CreateUserCommand : ICreateUserCommand, ICommandBase<CreateUserRequest, bool>
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

        [Obsolete("METODO NÃO ESTA FUNCIONAL", false)]
        public async Task<bool> ExecuteAsync(CreateUserRequest userRequest)
        {
            ValidateInput(userRequest);
            var user = _converter.CreateUser(userRequest);
            await _commandRepository.RegisterAsync(user);
            await _unitOfWork.CommitAsync();
            await Task.Delay(TimeSpan.FromSeconds(3));
            return true;
        }

        private void ValidateInput(CreateUserRequest input)
        {
            throw new NotImplementedException();
        }
    }
}
