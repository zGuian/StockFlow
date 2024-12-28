using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Exceptions;
using FlowStockManager.Domain.Interfaces.Repositories;
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

        public async Task<IEnumerable<Tuple<Product, int>>> FindDataBaseAsync(Dictionary<Guid, int> dict)
        {
            var ids = dict.Keys.ToList();
            var resultDb = await _context.Products
                .AsNoTracking()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();
            if (resultDb.Count != 0)
            {
                var newTuple = new List<Tuple<Product, int>>();
                foreach (var item in resultDb)
                {
                    if (dict.TryGetValue(item.Id, out var value))
                    {
                        newTuple.Add(Tuple.Create(item, value));
                    }
                }
                return newTuple;
            }
            throw new NotFoundExceptions($"Não encontrado nenhum produto");
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
            return entry.Entity;
        }

        public async Task<Product> UpdateDataBaseAsync(Product entity)
        {
            var productFound = await FindDataBaseAsync(entity.Id);
            _context.Entry(productFound).CurrentValues.SetValues(entity);
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

        public async Task<IEnumerable<Tuple<Product, int>>> VerifyDataBaseDisponibleProduct(Dictionary<Guid, int> dictionary)
        {
            var productIds = dictionary.Keys.ToList();
            var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();
            var productDict = products.ToDictionary(p => p.Id);
            var tuples = new List<Tuple<Product, int>>();
            foreach (var kvp in dictionary)
            {
                if (productDict.TryGetValue(kvp.Key, out var product))
                {
                    tuples.Add(new Tuple<Product, int>(product, kvp.Value));
                }
            }
            return tuples;
        }

        public async Task UpdateDataBaseAsync(IEnumerable<Product> products)
        {
            var productsIds = products.Select(x => x.Id);
            var result = await _context.Products
                .Where(p => productsIds.Contains(p.Id))
                .ToListAsync();
            
            var productArray = new Product[result.Count];
            for (int i = 0; i < result.Count; i++)
            {
                productArray[i] = result[i];
            }
            _context.Products.UpdateRange(productArray);
        }

        public async Task UpdateDataBaseAsync(IEnumerable<Tuple<Product, int>> tuple)
        {
            var productsIds = tuple.Select(x => x.Item1.Id);
            var quantity = tuple.Select(x => x.Item2).ToArray();
            var result = await _context.Products
                .Where(p => productsIds.Contains(p.Id))
                .ToListAsync();
            result = result.OrderBy(p => productsIds.ToList().IndexOf(p.Id)).ToList();
            var productArray = new Product[result.Count];
            for (int i = 0; i < result.Count; i++)
            {
                result[i].ConsumeProduct(quantity[i]);
                productArray[i] = result[i];
            }
            _context.Products.UpdateRange(productArray);
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await FindDataBaseAsync(id);
            _context.Products.Remove(product);
        }
    }
}
