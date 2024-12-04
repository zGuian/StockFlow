namespace FlowStockManager.Domain.Requests.OrderRequest.DtoRequest
{
    public record ProductDtoRequest
    {
        public Guid ProductId { get; init; }
        public int QtdProduct { get; init; }
    }
}
