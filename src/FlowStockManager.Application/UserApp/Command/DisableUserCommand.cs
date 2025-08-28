using FlowStockManager.Application.Commons.Interface;
using FlowStockManager.Application.UserApp.Interfaces;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Repositories.Commands;

namespace FlowStockManager.Application.UserApp.Command
{
    public class DisableUserCommand : IDisableUserCommand, ICommandBase<string, bool>
    {
        private readonly IUserCommandRepository _commandRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DisableUserCommand(IUserCommandRepository commandRepository, IUnitOfWork unitOfWork)
        {
            _commandRepository = commandRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ExecuteAsync(string request)
        {
            await _commandRepository.DisableAsync(request);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
