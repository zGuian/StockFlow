using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

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

        public Task<IEnumerable<OrderProduct>> FindDataBaseAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> RegisterDataBaseAsync(IEnumerable<OrderProduct> orderProducts)
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
            return orderProducts.First().Orders;
        }

        //public async Task ConsumeAsync(IEnumerable<OrderProduct> orderProducts, Order order)
        //{
        //    foreach (var item in orderProducts)
        //    {
        //        var product = await _context.Products
        //            .AsNoTracking()
        //            .FirstOrDefaultAsync(p => p.Id == item.ProductId);
        //        if (product != null)
        //        {
        //            item.UpdateOrderProduct(product, item.ProductQuantity);
        //            _context.Products.Update(product);
        //            _context.Orders.Update(order);
        //        }
        //    }
        //}

        public async Task ConsumeAsync(Order order)
        {
            var listOp = await _context.OrderProducts
                .AsNoTracking()
                .Where(op => op.OrderId == order.Id)
                .ToListAsync();
            var updates = new List<OrderProduct>();
            foreach (var item in listOp)
            {
                item.UpdateOrderProduct(item.Product, item.ProductQuantity);
                updates.Add(item);
            }
            AddUpdate(updates);
        }

        private void AddUpdate(List<OrderProduct> orderProducts)
        {
            _context.Products.UpdateRange(orderProducts.Select(x => x.Product));
            _context.Orders.UpdateRange(orderProducts.Select(x => x.Orders));
        }
    }
}
