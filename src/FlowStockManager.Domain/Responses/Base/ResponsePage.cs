using System.Text.Json.Serialization;

namespace FlowStockManager.Domain.Responses.Base
{
    public class ResponsePage<TEntity> where TEntity : class
    {
        [JsonPropertyOrder(2)]
        public int PageSize { get; private set; } = 25;

        [JsonPropertyOrder(3)]
        public int PageNumber { get; private set; } = 1;

        [JsonPropertyOrder(4)]
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        [JsonPropertyOrder(5)]
        public int CurrentPage { get; private set; }

        [JsonPropertyOrder(6)]
        public TEntity? Entity { get; set; }

        [JsonPropertyOrder(1)]
        public string? Message { get; set; }

        [JsonPropertyOrder(0)]
        public int TotalCount { get; set; }

        protected ResponsePage() { }

        private ResponsePage(TEntity? entity, int totalCount, int currentPage = 1, int pageSize = 25)
        {
            Entity = entity;
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
        }

        public static class Factories
        {
            public static ResponsePage<TEntity> CreateResponsePaged(TEntity? entity, int totalCount, int currentPage = 1, int pageSize = 25)
            {
                return new ResponsePage<TEntity>(entity, totalCount, currentPage, pageSize);
            }
        }
    }
}
