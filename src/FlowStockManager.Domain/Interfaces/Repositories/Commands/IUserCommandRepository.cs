using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Repositories.Commands
{
    public interface IUserCommandRepository : IBaseCommandRepository<User, string>
    {
    }
}
