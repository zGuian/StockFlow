using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Exceptions;
using FlowStockManager.Domain.Interfaces;
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

        public async Task<Order> GetAsync(Guid orderId)
        {
            var orderFound = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            if (orderFound != null)
            {
                return orderFound;
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
            var orderUpdated = _context.Orders.Update(order);
            if (orderUpdated.State != EntityState.Modified)
            {
                throw new InvalidOperationException("Houve um erro ao atualizar pedido");
            }
            await _context.SaveChangesAsync();
        }
    }
}
