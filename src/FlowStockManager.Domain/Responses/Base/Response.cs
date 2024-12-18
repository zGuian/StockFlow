using System.ComponentModel;
using System.Text.Json.Serialization;

namespace FlowStockManager.Domain.Responses.Base
{
    public class Response<TEntity> where TEntity : class
    {
        [JsonPropertyOrder(2)]
        public bool Sucess { get; set; } = true;

        [JsonPropertyOrder(3)]
        [DisplayName("Data")]
        public TEntity? Entity { get; set; }

        [JsonPropertyOrder(1)]
        public string? Message { get; set; }

        [JsonPropertyOrder(0)]
        public int TotalCount { get; set; }

        protected Response() { }

        private Response(TEntity? entity, bool sucess, string? message = null)
        {
            Entity = entity;
            Sucess = sucess;
            Message = message;
        }

        public static class Factories
        {
            public static Response<TEntity> CreateResponse(TEntity? entity, bool sucess, string? message = null)
            {
                return new Response<TEntity>(entity, sucess, message);
            }
        }
    }
}
