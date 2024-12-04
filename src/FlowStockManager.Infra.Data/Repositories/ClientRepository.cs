using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Exceptions;
using FlowStockManager.Domain.Interfaces;
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

        public async Task<Client> FindDataBaseAsync(Guid id)
        {
            var respSql = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (respSql != null)
            {
                return respSql;
            }
            throw new NotFoundExceptions($"Não encontrado nenhum cliente com esse ID: {id}");
        }
    }
}
