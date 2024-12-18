using FlowStockManager.Domain.DTOs.Clients;
using System.Text.Json.Serialization;

namespace FlowStockManager.Domain.Responses.ClientResponse
{
    public class ClientResponseView
    {
        [JsonPropertyOrder(0)]
        public bool Sucess { get; set; } = true;

        [JsonPropertyOrder(8)]
        protected ClientDto? Entity { get; set; }

        [JsonPropertyOrder(2)]
        public string? Message { get; set; }

        [JsonPropertyOrder(1)]
        public int TotalCount { get; set; }

        protected ClientResponseView() { }

        private ClientResponseView(ClientDto? entity, int totalCount, string? message = null)
        {
            Entity = entity;
            Message = message;
            TotalCount = totalCount;
        }

        private ClientResponseView(ClientDto? entity, bool sucess, string? message = null)
        {
            Entity = entity;
            Sucess = sucess;
            Message = message;
        }

        public static class Factories
        {
            public static ClientResponseView CreateResponseView(ClientDto? entity, int totalCount, string? message = null)
            {
                return new ClientResponseView(entity, totalCount, message);
            }

            public static ClientResponseView CreateResponseView(ClientDto? entity, bool sucess, string? message = null)
            {
                return new ClientResponseView(entity, sucess, message);
            }
        }
    }
}
