using FlowStockManager.Domain.Interfaces;
using FlowStockManager.Infra.Data.Context;

namespace FlowStockManager.Infra.Data.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _context;

        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
