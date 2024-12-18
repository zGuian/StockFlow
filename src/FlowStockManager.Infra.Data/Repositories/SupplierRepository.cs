using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Exceptions;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FlowStockManager.Infra.Data.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _context;

        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> FindDataBaseAsync(int skip, int take)
        {
            var query = _context.Suppliers.AsQueryable().AsNoTracking();
            query.Take(take).Skip((skip - 1) * take);
            return await query.ToListAsync();
        }

        public async Task<Supplier> FindDataBaseAsync(Guid id)
        {
            var resultDb = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == id);
            if (resultDb != null)
            {
                return resultDb;
            }
            throw new NotFoundExceptions($"Não encontrado nenhum produto com Id: [{id}]");
        }

        public async Task<Supplier> RegisterDataBaseAsync(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<Supplier> UpdateDataBaseAsync(Supplier supplier)
        {
            var supplierFound = await FindDataBaseAsync(supplier.Id);
            _context.Entry(supplierFound).CurrentValues.SetValues(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var supplier = await FindDataBaseAsync(id);
            _context.Suppliers.Remove(supplier);
            return await _context.SaveChangesAsync();
        }
    }
}
