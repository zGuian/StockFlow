using FlowStockManager.Domain.DTOs.Clients;
using FlowStockManager.Domain.Interfaces.Handlers;
using FlowStockManager.Domain.Interfaces.Services;
using FlowStockManager.Domain.Interfaces.UseCases;
using FlowStockManager.Domain.Requests.ClientRequest;
using FlowStockManager.Domain.Responses.Base;

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

        public async Task<ResponsePage<IEnumerable<ClientDto>>> GetAsync(int take, int skip)
        {
            var clients = await _service.GetAsync(take, skip);
            var count = clients.Count();
            var dto = _useCase.EnumerableToDto(clients);
            return ResponsePage<IEnumerable<ClientDto>>.Factories.CreateResponsePaged(dto, count);
        }

        public async Task<Response<ClientDto>> GetAsync(Guid id)
        {
            var client = await _service.GetAsync(id);
            var dto = _useCase.ToDto(client);
            return Response<ClientDto>.Factories.CreateResponse(dto, true);
        }

        public async Task<Response<ClientDto>> RegisterAsync(CreateClientRequest clientRequest)
        {
            var entity = _useCase.ToEntity(clientRequest);
            entity = await _service.RegisterAsync(entity);
            var dto = _useCase.ToDto(entity);
            return Response<ClientDto>.Factories.CreateResponse(dto, true);
        }

        public async Task<Response<ClientDto>> UpdateAsync(UpdateClientRequest clientRequest)
        {
            var entity = _useCase.ToEntity(clientRequest);
            entity = await _service.UpdateAsync(entity);
            var dto = _useCase.ToDto(entity);
            return Response<ClientDto>.Factories.CreateResponse(dto, true);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            return;
        }
    }
}
