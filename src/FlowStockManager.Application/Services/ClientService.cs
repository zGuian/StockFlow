using FlowStockManager.Domain.Entities;
using FlowStockManager.Domain.Interfaces.Repositories;
using FlowStockManager.Domain.Interfaces.Services;

namespace FlowStockManager.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClientRepository _clientRepository;

        public ClientService(IUnitOfWork unitOfWork, IClientRepository clientRepository)
        {
            _unitOfWork = unitOfWork;
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<Client>> GetAsync(int take, int skip) => 
            await _clientRepository.FindDataBaseAsync(take, skip);

        public async Task<Client> GetAsync(Guid id) => await _clientRepository.FindDataBaseAsync(id);

        public async Task<Client> RegisterAsync(Client entity)
        {
            var client = await _unitOfWork.ClientRepository.RegisterDataBaseAsync(entity);
            return client;
        }

        public async Task<Client> UpdateAsync(Client entity)
        {
            var client = await _unitOfWork.ClientRepository.UpdateDataBaseAsync(entity);
            return client;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.ClientRepository.DeleteAsync(id);
        }
    }
}
