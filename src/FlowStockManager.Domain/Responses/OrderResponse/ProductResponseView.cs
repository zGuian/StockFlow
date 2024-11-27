namespace FlowStockManager.Domain.Responses.ProductResponse
{
    public class OrderResponseView<T> where T : class
    {
        public int TotalValue { get; private set; }
        public T Content { get; private set; }
        
        private OrderResponseView(T content)
        {
            Content = content;
        }

        public static class Factories
        {
            public static OrderResponseView<T> CreateResponseView(T content)
            {
                return new OrderResponseView<T>(content);
            }
        }
    }
}
