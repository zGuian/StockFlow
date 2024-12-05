namespace FlowStockManager.Domain.Responses.ClientResponse
{
    public class ClientResponseView<T> where T : class
    {
        public int TotalValue { get; private set; }
        public IEnumerable<T> Content { get; private set; }

        private ClientResponseView(IEnumerable<T> content)
        {
            Content = content;
        }

        public static class Factories
        {
            public static ClientResponseView<T> CreateResponseView(IEnumerable<T> content)
            {
                return new ClientResponseView<T>(content);
            }
        }
    }
}
