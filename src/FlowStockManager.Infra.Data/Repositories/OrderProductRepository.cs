using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces;
using FlowStockManager.Infra.Data.Context;

namespace FlowStockManager.Infra.Data.Repositories
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly AppDbContext _context;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderProductRepository(AppDbContext context, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task<Order> RegisterDataBaseAsync(IEnumerable<OrderProduct> orderProducts)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach (var item in orderProducts)
                    {
                        var pFound = await _productRepository.FindDataBaseAsync(item.ProductId);
                        if (pFound != null)
                        {
                            _context.Entry(pFound).CurrentValues.SetValues(item.Product);
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
