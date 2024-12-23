namespace FlowStockManager.Domain.Responses.Base
{
    public abstract class ResponseView<T> where T : class
    {
        public int TotalValue { get; set; }
        public List<T> Content { get; set; } = null!;
    }
}
