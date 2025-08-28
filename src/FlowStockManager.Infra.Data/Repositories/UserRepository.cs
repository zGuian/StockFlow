using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.Repositories.Commands;
using FlowStockManager.Domain.Interfaces.Repositories.Queries;
using FlowStockManager.Infra.Data.Context;

namespace FlowStockManager.Infra.Data.Repositories
{
    public sealed class UserRepository : BaseRepository<User, string>, IUserCommandRepository, IUserQueryRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task DisableAsync(string request)
        {
            var user = await base.GetByIdAsync(request);
            user.DisableUser();
            base.Update(user);
        }
    }
}
