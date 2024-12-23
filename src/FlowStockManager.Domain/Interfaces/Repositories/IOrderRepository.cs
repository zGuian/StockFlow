using FlowStockManager.Domain.Entities;
using System.Linq.Expressions;

namespace FlowStockManager.Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> FindEverythingWithPendingStatusAsync(Expression<Func<Order, bool>> predicate);
    }
}
