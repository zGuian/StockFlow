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
            var query = _context.Products.AsQueryable().AsNoTracking();
            query.Take(take).Skip((skip - 1) * take);
            return await query.ToListAsync();
        }

        public async Task<Product> FindDataBaseAsync(Guid id)
        {
            var resultDb = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
            if (resultDb != null)
            {
                return resultDb;
            }
            throw new NotFoundExceptions($"Não encontrado nenhum produto com Id: [{id}]");
        }

        public async Task<IEnumerable<Product>> FindDataBaseAsync(IEnumerable<Guid> productIds)
        {
            var products = new List<Product>();
            foreach (var item in productIds)
            {
                var product = await _context.Products
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == item);
                if (product != null)
                {
                    products.Add(product);
                }
                Console.WriteLine("------------------------------------------------------------------------------------");
                Console.WriteLine($"Não encontrado nenhum produto com ID: {item}");
                Console.WriteLine("------------------------------------------------------------------------------------");
            }
            if (products.Count > 0)
            {
                return products;
            }
            throw new NotFoundExceptions("Não encontrado nenhum produto.");
        }

        public async Task<Product> RegisterDataBaseAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            var changedLine = await _context.SaveChangesAsync();
            if (changedLine < 1)
            {
                throw new DbUpdateException("Não foi possivel realizar a alteração do produto");
            }
            return product;
        }

        public async Task<Product> UpdateDataBaseAsync(Product product)
        {
            var productFound = await FindDataBaseAsync(product.Id);
            _context.Entry(productFound).CurrentValues.SetValues(product);
            var changedLine = await _context.SaveChangesAsync();
            if (changedLine < 1)
            {
                throw new DbUpdateException("Não foi possivel realizar a alteração do produto");
            }
            return product;
        }

        public async Task DeleteInDataBaseAsync(Guid id)
        {
            var product = await FindDataBaseAsync(id);
            _context.Products.Remove(product);
            var changedLine = await _context.SaveChangesAsync();
            if (changedLine < 1)
            {
                throw new DbUpdateException("Não foi possivel realizar a alteração do produto");
            }
            return;
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
    }
}
