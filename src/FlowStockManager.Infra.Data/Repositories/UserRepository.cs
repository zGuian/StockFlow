using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.Repositories.Commands;
using FlowStockManager.Domain.Interfaces.Repositories.Queries;
using FlowStockManager.Infra.Data.Context;

namespace FlowStockManager.Infra.Data.Repositories
{
    public sealed class UserRepository : BaseRepository<User, string>, IUserCommandRepository, IUserQueryRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
