using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Exceptions;
using FlowStockManager.Domain.Interfaces;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;
using FlowStockManager.Infra.Data.Context;
using Microsoft.Data.SqlClient;
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
            var resultDb = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (resultDb != null)
            {
                return resultDb;
            }
            throw new NotFoundExceptions($"Não encontrado nenhum produto com Id: [{id}]");
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

        //public async Task<IEnumerable<Product>> ConsumeProductAsync(List<Product> productUpdate)
        //{
        //    using (var context = _context)
        //    {
        //        var productList = new List<Product>();
        //        SqlParameter[] parameters = [];
        //        foreach (var product in productUpdate)
        //        {
        //            parameters[0] = new SqlParameter("@Id", product.Id);

        //        };
        //        var products = context.Database.SqlQueryRaw<ConsumeProductDto>("SP_ConsumesProducts @Id, @Name, @Description, " +
        //            "@Price, @StockQuantity, @SupplierId", parameters).AsQueryable();

        //        foreach (var item in products)
        //        {
        //            productList.Add(Product.Factories.Product(item.Id, item.Name, item.Description, item.Price,
        //                item.StockQuantity, item.SupplierId));
        //        }
        //    }
        //}

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
    }
}
