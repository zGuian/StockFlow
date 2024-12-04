using FlowStockManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowStockManager.Domain.Interfaces
{
    public interface IOrderProductRepository
    {
        Task<Order> RegisterDataBaseAsync(IEnumerable<OrderProduct> orderProducts);
    }
}
