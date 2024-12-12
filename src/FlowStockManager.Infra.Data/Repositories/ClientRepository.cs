using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Exceptions;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FlowStockManager.Infra.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> FindDataBaseAsync(int take, int skip)
        {
            var query = _context.Clients
                .AsNoTracking();
            query.Take(take).Skip((skip - 1) * take);
            return await query.ToListAsync();
        }

        public async Task<Client> FindDataBaseAsync(Expression<Func<Client, bool>> predicate)
        {
            var respSql = await _context.Clients
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);
            if (respSql != null)
            {
                return respSql;
            }
            throw new NotFoundExceptions($"Não encontrado nenhum cliente com esse ID: {predicate}");
        }

        public async Task<Client> RegisterDataBaseAsync(Client entity)
        {
            await _context.Clients.AddAsync(entity);
            var changedLine = await _context.SaveChangesAsync();
            if (changedLine < 1)
            {
                throw new DbUpdateException("Não foi possivel realizar a alteração do produto");
            }
            return entity;
        }

        public async Task<Client> UpdateDataBaseAsync(Client entity)
        {
            var clientFound = await FindDataBaseAsync(c => c.Id == entity.Id);
            _context.Entry(clientFound).CurrentValues.SetValues(entity);
            var changedLine = await _context.SaveChangesAsync();
            if (changedLine < 1)
            {
                throw new DbUpdateException("Não foi possivel realizar a alteração do produto");
            }
            return entity;
        }

        public async Task<int> DeleteAsync(Expression<Func<Client, bool>> predicate)
        {
            var client = await FindDataBaseAsync(predicate);
            _context.Clients.Remove(client);
            return await _context.SaveChangesAsync();
        }
    }
}
