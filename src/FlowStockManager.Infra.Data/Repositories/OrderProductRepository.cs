using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Exceptions;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FlowStockManager.Infra.Data.Repositories
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly AppDbContext _context;

        public OrderProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderProduct>> FindAllProductByOrder(Guid id)
        {
            var query = _context.OrderProducts
                .AsNoTracking()
                .Include(op => op.Orders)
                .Include(op => op.Product)
                .Where(op => op.Orders.Id == id);
            return await query.ToListAsync();
        }

        public async Task<OrderProduct> FindDataBaseAsync(Expression<Func<OrderProduct, bool>> predicate)
        {
            return await _context.OrderProducts.FirstOrDefaultAsync(predicate) ?? throw new NotFoundExceptions("Não encontrado");
        }

        public Task<IEnumerable<OrderProduct>> FindDataBaseAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> RegisterDataBaseAsync(IEnumerable<OrderProduct> orderProducts)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach (var item in orderProducts)
                    {
                        var existingProduct = await _context.Products.FindAsync(item.ProductId);
                        if (existingProduct != null)
                        {
                            item.AddProduct(existingProduct);
                        }
                        await _context.OrderProducts.AddAsync(item);
                    }
                    var respSql = await _context.SaveChangesAsync();
                    if (respSql > 0)
                    {
                        await transaction.CommitAsync();
                        return orderProducts.First().Orders;
                    }
                    throw new Exception("Ocorreu um problema ao registrar mudanças no banco");
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task ConsumeAsync(IEnumerable<OrderProduct> orderProducts, Order order)
        {
            foreach (var item in orderProducts)
            {
                var product = await _context.Products
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == item.ProductId);
                if (product != null)
                {
                    OrderProduct.UpdateOrderProduct(item, product, item.ProductQuantity);
                    _context.Products.Update(product);
                    _context.Orders.Update(order);
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Expression<Func<OrderProduct, bool>> predicate)
        {
            var entity = await _context.OrderProducts.FirstOrDefaultAsync(predicate)
                ?? throw new NotFoundExceptions("Não encontrado");
            _context.OrderProducts.Remove(entity);
            var remove = await _context.SaveChangesAsync();
            return remove;
        }

        public Task<OrderProduct> RegisterDataBaseAsync(OrderProduct entity)
        {
            throw new NotImplementedException();
        }

        public Task<OrderProduct> UpdateDataBaseAsync(OrderProduct entity)
        {
            throw new NotImplementedException();
        }
    }
}
