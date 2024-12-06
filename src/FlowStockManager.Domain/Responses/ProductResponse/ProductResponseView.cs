namespace FlowStockManager.Domain.Responses.ProductResponse
{
    public class ProductResponseView<T> where T : class
    {
        public int TotalValue { get; private set; }
        public IEnumerable<T> Content { get; private set; }

        private ProductResponseView(IEnumerable<T> content)
        {
            Content = content;
            TotalValue = content.Count();
        }

        public static class Factories
        {
            public static ProductResponseView<T> CreateResponseView(IEnumerable<T> @object)
            {
                return new ProductResponseView<T>(@object);
            }
        }
    }
}
