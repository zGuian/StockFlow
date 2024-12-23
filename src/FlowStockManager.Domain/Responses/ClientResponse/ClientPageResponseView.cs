using FlowStockManager.Domain.DTOs.Clients;
using System.Text.Json.Serialization;

namespace FlowStockManager.Domain.Responses.ClientResponse
{
    internal class ClientPageResponseView : ClientResponseView
    {
        [JsonPropertyOrder(5)]
        public int PageSize { get; private set; } = 25;

        [JsonPropertyOrder(4)]
        public int PageNumber { get; private set; } = 1;

        [JsonPropertyOrder(6)]
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        [JsonPropertyOrder(7)]
        public int CurrentPage { get; private set; }

        protected ClientPageResponseView() { }

        public ClientPageResponseView(ClientDto? entity, int totalCount, int currentPage = 1, int pageSize = 25)
        {
            Entity = entity;
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
        }

        public ClientPageResponseView(bool sucess, string? message)
        {
            Sucess = sucess;
            Message = message;
        }

        public ClientPageResponseView(ClientDto entity, bool sucess, string? message = null)
        {
            Entity = entity;
            Sucess = sucess;
            Message = message;
        }
    }
}
