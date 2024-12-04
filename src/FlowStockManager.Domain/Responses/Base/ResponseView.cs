namespace FlowStockManager.Domain.Responses.Base
{
    public abstract class ResponseView<T> where T : class
    {
        public int TotalValue { get; set; }
        public T Content { get; set; } = null!;
    }
}
