using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Infra.Data.Context;

namespace FlowStockManager.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ISupplierRepository? _supplierRepository;
        private IProductRepository? _productRepository;
        private IOrderRepository? _orderRepository;
        private IClientRepository? _clientRepository;
        private IOrderProductRepository? _orderProductRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public ISupplierRepository SupplierRepository
        {
            get
            {
                return _supplierRepository ??= new SupplierRepository(_context);
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository ??= new ProductRepository(_context);
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                return _orderRepository ??= new OrderRepository(_context);
            }
        }
        public IClientRepository ClientRepository
        {
            get
            {
                return _clientRepository ??= new ClientRepository(_context);
            }
        }

        public IOrderProductRepository OrderProductRepository
        {
            get
            {
                return _orderProductRepository ??= new OrderProductRepository(_context);
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
