using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces;
using FlowStockManager.Infra.Data.Context;

namespace FlowStockManager.Infra.Data.Repositories
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly AppDbContext _context;

        public OrderProductRepository(AppDbContext context)
        {
            _context = context;
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
    }
}
