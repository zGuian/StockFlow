using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Exceptions;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
            var query = _context.Products.AsQueryable().AsNoTracking();
            query.Take(take).Skip((skip - 1) * take);
            return await query.ToListAsync();
        }

        public async Task<Product> FindDataBaseAsync(Expression<Func<Product, bool>> predicate)
        {
            var resultDb = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);
            if (resultDb != null)
            {
                return resultDb;
            }
            throw new NotFoundExceptions($"Não encontrado nenhum produto com Id: [{predicate}]");
        }

        public async Task<IEnumerable<Product>> FindDataBaseAsync(IEnumerable<Guid> productIds)
        {
            var products = new List<Product>();
            foreach (var item in productIds)
            {
                var product = await _context.Products
                    .AsNoTracking()
                    .Include(s => s.Supplier)
                    .FirstOrDefaultAsync(p => p.Id == item);
                if (product != null)
                {
                    products.Add(product);
                }
                Console.WriteLine("------------------------------------------------------------------------------------");
                Console.WriteLine($"Não encontrado nenhum produto com ID: {item}");
                Console.WriteLine("------------------------------------------------------------------------------------");
            }
            if (products.Count < 0) { throw new NotFoundExceptions("Não encontrado nenhum produto."); }
                return products;
            }

        public async Task<Product> RegisterDataBaseAsync(Product entity)
        {
            var entry = await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<Product> UpdateDataBaseAsync(Product entity)
        {
            var productFound = await FindDataBaseAsync(p => p.Id == entity.Id);
            _context.Entry(productFound).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> VerifyQuantityInDataBaseAsync(List<Guid> productsId)
        {
            var query = _context.Products.Where(p => productsId.Contains(p.Id) && p.StockQuantity <= 0);
            await query.ToListAsync();
            if (query.Any())
            {
                return true;
            }
            return false;
        }

        public bool VerifyDataBaseDisponibleProduct(List<Guid> productsId)
        {
            return _context.Products.Where(p => productsId.Contains(p.Id)).All(p => p.StockQuantity >= 1);
        }

        public async Task UpdateDataBaseAsync(IEnumerable<Product> products)
        {
            _context.Products.UpdateRange(products);
            await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Expression<Func<Product, bool>> predicate)
        {
            var product = await FindDataBaseAsync(predicate);
            _context.Products.Remove(product);
            var save = await _context.SaveChangesAsync();
            if (save < 1)
            {
                throw new DbUpdateException("Não foi possivel realizar a alteração do produto");
            }
            return save;
        }
    }
}
