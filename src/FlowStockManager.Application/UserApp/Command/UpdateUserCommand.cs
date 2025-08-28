using FlowStockManager.Application.Commons.Interface;
using FlowStockManager.Application.Converters.Interfaces;
using FlowStockManager.Application.UserApp.Interfaces;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Repositories.Commands;
using FlowStockManager.Domain.Requests.UserRequests;

namespace FlowStockManager.Application.UserApp.Command
{
    internal class UpdateUserCommand : IUpdateUserCommand, ICommandBase<UpdateUserRequest, bool>
    {
        private readonly IUserCommandRepository _commandRepository;
        private readonly IUserConverter _converter;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommand(IUserCommandRepository commandRepository, IUserConverter converter, IUnitOfWork unitOfWork)
        {
            _commandRepository = commandRepository;
            _converter = converter;
            _unitOfWork = unitOfWork;
        }

        [Obsolete("METODO NÃO ESTA FUNCIONAL", false)]
        public async Task<bool> ExecuteAsync(UpdateUserRequest request)
        {
            ValidateInput(request);
            var user = _converter.ToEntity(request);
            _commandRepository.Update(user);
            await _unitOfWork.CommitAsync();
            return true;
        }

        private void ValidateInput(UpdateUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
