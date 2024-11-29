using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Exceptions;
using FlowStockManager.Domain.Interfaces;
using FlowStockManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FlowStockManager.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> FindDataBaseAsync(int take, int skip)
        {
            using (var context = _context)
            {
                var query = context.Products.AsQueryable().AsNoTracking();
                query.Take(take).Skip((skip - 1) * take);
                return await query.ToListAsync();
            }
        }

        public async Task<Product> FindDataBaseAsync(Guid id)
        {
            using (var context = _context)
            {
                var resultDb = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (resultDb != null)
                {
                    return resultDb;
                }
                throw new NotFoundExceptions($"Não encontrado nenhum produto com Id: [{id}]");
            }
        }

        public async Task<Product> RegisterDataBaseAsync(Product product)
        {
            using (var context = _context)
            {
                await context.Products.AddAsync(product);
                var changedLine = await context.SaveChangesAsync();
                if (changedLine < 1)
                {
                    throw new DbUpdateException("Não foi possivel realizar a alteração do produto");
                }
                return product;
            }
        }

        public async Task<Product> UpdateDataBaseAsync(Product product)
        {
            using (var context = _context)
            {
                var productFound = await FindDataBaseAsync(product.Id);
                context.Entry(productFound).CurrentValues.SetValues(product);
                var changedLine = await context.SaveChangesAsync();
                if (changedLine < 1)
                {
                    throw new DbUpdateException("Não foi possivel realizar a alteração do produto");
                }
                return product;
            }
        }

        public async Task DeleteInDataBaseAsync(Guid id)
        {
            using (var context = _context)
            {
                var product = await FindDataBaseAsync(id);
                context.Products.Remove(product);
                var changedLine = await context.SaveChangesAsync();
                if (changedLine < 1)
                {
                    throw new DbUpdateException("Não foi possivel realizar a alteração do produto");
                }
                return;
            }
        }

        public async Task<bool> VerifyQuantityInDataBaseAsync(List<Guid> productsId)
        {
            using (var context = _context)
            {
                var query = context.Products.Where(p => productsId.Contains(p.Id) && p.StockQuantity <= 0);
                await query.ToListAsync();
                if (query.Any())
                {
                    return true;
                }
                return false;
            }
        }

        public bool VerifyDataBaseDisponibleProduct(List<Guid> productsId)
        {
            using (var context = _context)
            {
                return context.Products.Where(p => productsId.Contains(p.Id)).All(p => p.StockQuantity >= 1);
            }
        }

        public async Task UpdateDataBaseAsync(IEnumerable<Product> products)
        {
            using (var context = _context)
            {
                context.Products.UpdateRange(products);
                await context.SaveChangesAsync();
            }
        }
    }
}
