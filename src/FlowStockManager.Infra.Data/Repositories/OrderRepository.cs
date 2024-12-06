using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Entities.Enums;
using FlowStockManager.Domain.Exceptions;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FlowStockManager.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAsync()
        {
            var ordersFound = await _context.Orders.Where(o => o.OrderStatus == OrderStatus.Pending).ToListAsync();
            if (ordersFound.Count != 0)
            {
                return ordersFound;
            }
            throw new NotFoundExceptions("Não foi encontrado nenhum pedido pendente");
        }

        public async Task<Order> GetAsync(Guid orderId)
        {
            var query = _context.Orders.AsQueryable()
                .AsNoTracking()
                .Include(o => o.OrderProducts);
            var resultSql = await query.FirstOrDefaultAsync(o => o.Id == orderId);
            if (resultSql != null)
            {
                return resultSql;
            }
            throw new NotFoundExceptions("Não encontrado nenhum pedido");
        }

        public async Task<Order> RegisterDataBaseAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            var changedLine = await _context.SaveChangesAsync();
            if (changedLine < 1)
            {
                throw new DbUpdateException("Não foi possivel realizar a alteração do produto");
            }
            return order;
        }

        public async Task UpdateDataBaseAsync(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
