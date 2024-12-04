namespace FlowStockManager.Domain.Responses.OrderResponse
{
    public class OrderResponseView<T> where T : class
    {
        public int TotalValue { get; private set; }
        public IEnumerable<T> Content { get; private set; }

        private OrderResponseView(IEnumerable<T> content)
        {
            Content = content;
        }

        public static class Factories
        {
            public static OrderResponseView<T> CreateResponseView(IEnumerable<T> content)
            {
                return new OrderResponseView<T>(content);
            }
        }
    }
}
