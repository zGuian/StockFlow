using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Exceptions;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

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
                .AsQueryable()
                .AsNoTracking();
            query.Take(take).Skip((skip - 1) * take);
            return await query.ToListAsync();
        }

        public async Task<Client> FindDataBaseAsync(Guid id)
        {
            var respSql = await _context.Clients
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (respSql != null)
            {
                return respSql;
            }
            throw new NotFoundExceptions($"Não encontrado nenhum cliente com esse ID: {id}");
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
            var clientFound = await FindDataBaseAsync(entity.Id);
            _context.Entry(clientFound).CurrentValues.SetValues(entity);
            var changedLine = await _context.SaveChangesAsync();
            if (changedLine < 1)
            {
                throw new DbUpdateException("Não foi possivel realizar a alteração do produto");
            }
            return entity;
        }

        public async Task DeleteDataBaseAsync(Guid id)
        {
            var client = await FindDataBaseAsync(id);
            _context.Clients.Remove(client);
            var changedLine = await _context.SaveChangesAsync();
            if (changedLine < 1)
            {
                throw new DbUpdateException("Não foi possivel realizar a alteração do produto");
            }
            return;
        }
    }
}
