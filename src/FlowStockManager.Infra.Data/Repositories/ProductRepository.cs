using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.Repositories.Commands;
using FlowStockManager.Domain.Interfaces.Repositories.Queries;
using FlowStockManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FlowStockManager.Infra.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product, string>, IProductQueryRepository, IProductCommandRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> FindDataBaseAsync(int take, int skip)
        {
            var query = _context.Products.AsQueryable().AsNoTracking();
            query.Skip((skip - 1) * take).Take(take);
            return await query.ToListAsync();
        }
    }
}
