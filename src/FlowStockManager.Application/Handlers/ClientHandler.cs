using FlowStockManager.Application.Handlers.Interfaces;
using FlowStockManager.Application.Services.Interfaces;
using FlowStockManager.Application.UseCases.Interfaces;
using FlowStockManager.Domain.Requests.ClientRequest;
using FlowStockManager.Domain.Responses.ClientResponse;
using FlowStockManager.Infra.CrossCutting.DTOs.Clients;

namespace FlowStockManager.Application.Handlers
{
    public class ClientHandler : IClientHandler
    {
        private readonly IClientService _service;
        private readonly IClientUseCase _useCase;

        public ClientHandler(IClientService service, IClientUseCase useCase)
        {
            _service = service;
            _useCase = useCase;
        }

        public async Task<ClientResponseView<ClientDto>> GetAsync(int take, int skip)
        {
            var clients = await _service.GetAsync(take, skip);
            var dto = _useCase.EnumerableToDto(clients);
            return ClientResponseView<ClientDto>.Factories.CreateResponseView(dto);
        }

        public async Task<ClientResponseView<ClientDto>> GetAsync(Guid id)
        {
            var client = await _service.GetAsync(id);
            var dto = _useCase.ToDto(client);
            return ClientResponseView<ClientDto>.Factories.CreateResponseView(new[] { dto });
        }

        public async Task<ClientResponseView<ClientDto>> RegisterAsync(CreateClientRequest clientRequest)
        {
            var entity = _useCase.ToEntity(clientRequest);
            entity = await _service.RegisterAsync(entity);
            var dto = _useCase.ToDto(entity);
            return ClientResponseView<ClientDto>.Factories.CreateResponseView(new[] { dto });
        }

        public async Task<ClientResponseView<ClientDto>> UpdateAsync(UpdateClientRequest clientRequest)
        {
            var entity = _useCase.ToEntity(clientRequest);
            entity = await _service.UpdateAsync(entity);
            var dto = _useCase.ToDto(entity);
            return ClientResponseView<ClientDto>.Factories.CreateResponseView(new[] { dto });
        }

        public async Task DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return;
        }
    }
}
