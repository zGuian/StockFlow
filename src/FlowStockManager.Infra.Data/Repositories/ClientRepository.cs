﻿using FlowStockManager.Domain.Entities;
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
                .AsNoTracking();
            query.Take(take).Skip((skip - 1) * take);
            return await query.ToListAsync();
        }

        public async Task<Client> FindDataBaseAsync(Guid id)
        {
            var respSql = await _context.Clients
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine($"Encontrado ID: {id}");
            if (respSql != null)
            {
                return respSql;
            }
            throw new NotFoundExceptions($"Não encontrado nenhum cliente com esse ID: {id}");
        }

        public async Task<Client> RegisterDataBaseAsync(Client entity)
        {
            await _context.Clients.AddAsync(entity);
            return entity;
        }

        public async Task<Client> UpdateDataBaseAsync(Client entity)
        {
            var clientFound = await FindDataBaseAsync(entity.Id);
            _context.Entry(clientFound).CurrentValues.SetValues(entity);
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var client = await FindDataBaseAsync(id);
            _context.Clients.Remove(client);
            return;
        }
    }
}
