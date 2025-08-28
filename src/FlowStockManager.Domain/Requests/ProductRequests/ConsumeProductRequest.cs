namespace FlowStockManager.Domain.Requests.ProductRequests
{
    public class ConsumeProductRequest
    {
        public string ProductId { get; init; }
        public int Quantity { get; init; }
    }
}
