using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Exceptions;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FlowStockManager.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Order>> FindDataBaseAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> FindEverythingWithPendingStatusAsync(Expression<Func<Order, bool>> predicate)
        {
            var ordersFound = await _context.Orders
                .Where(predicate)
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .AsNoTracking()
                .ToListAsync();
            if (ordersFound.Count != 0)
            {
                return ordersFound;
            }
            throw new NotFoundExceptions("Não foi encontrado nenhum pedido pendente");
        }

        public async Task<Order> FindDataBaseAsync(Guid id)
        {
            var query = _context.Orders
                .AsNoTracking()
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product);
            var resultSql = await query.FirstOrDefaultAsync(o => o.Id == id);
            if (resultSql != null)
            {
                return resultSql;
            }
            throw new NotFoundExceptions("Não encontrado nenhum pedido");
        }

        public async Task<Order> RegisterDataBaseAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            return order;
        }

        public async Task<Order> UpdateDataBaseAsync(Order order)
        {
            var orderFound = await FindDataBaseAsync(order.Id);
            _context.Entry(orderFound).CurrentValues.SetValues(order);
            await _context.SaveChangesAsync();
            return orderFound;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await FindDataBaseAsync(id);
            _context.Remove(entity);
        }
    }
}
