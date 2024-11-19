namespace FlowStockManager.Domain.Responses.ProductResponse
{
    public class ProductResponseView<T> where T : class
    {
        public T Object { get; private set; }

        private ProductResponseView(T @object)
        {
            Object = @object;
        }

        public static class Factories
        {
            public static ProductResponseView<T> CreateResponseView(T @object)
            {
                return new ProductResponseView<T>(@object);
            }
        }
    }
}
