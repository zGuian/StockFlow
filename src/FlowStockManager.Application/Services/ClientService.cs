using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Services;

namespace FlowStockManager.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Client>> GetAsync(int take, int skip) => await _repository.FindDataBaseAsync(take, skip);

        public async Task<Client> GetAsync(Guid id) => await _repository.FindDataBaseAsync(id);

        public async Task<Client> RegisterAsync(Client entity) => await _repository.RegisterDataBaseAsync(entity);

        public async Task<Client> UpdateAsync(Client entity) => await _repository.UpdateDataBaseAsync(entity);

        public async Task DeleteAsync(Guid id) => await _repository.DeleteDataBaseAsync(id);
    }
}
