namespace FlowStockManager.Domain.Responses.ProductResponse
{
    public class ProductResponseView<T> where T : class
    {
        public IEnumerable<T> Object { get; private set; }
        
        private ProductResponseView(IEnumerable<T> @object)
        {
            Object = @object;
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
