using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.Repositories.Commands;
using FlowStockManager.Domain.Interfaces.Repositories.Queries;
using FlowStockManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FlowStockManager.Infra.Data.Repositories
{
    public class SupplierRepository : BaseRepository<Supplier, Guid>, ISupplierQueryRepository, ISupplierCommandRepository
    {
        private readonly AppDbContext _context;

        public SupplierRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> FindDataBaseAsync(int skip, int take)
        {
            var query = _context.Suppliers.AsQueryable().AsNoTracking();
            query.Skip((skip - 1) * take).Take(take);
            return await query.ToListAsync();
        }

        public async Task<bool> HasRegistered(string id) => await _context.Suppliers.AsNoTracking().AnyAsync(x => x.Equals(id));
    }
}
