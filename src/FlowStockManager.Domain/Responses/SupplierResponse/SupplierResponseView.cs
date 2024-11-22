namespace FlowStockManager.Domain.Responses.SupplierResponse
{
    public class SupplierResponseView<T> where T : class
    {
        public int TotalContent { get; private set; }
        public IEnumerable<T> Content { get; private set; }

        private SupplierResponseView(IEnumerable<T> content)
        {
            TotalContent = content.Count();
            Content = content;
        }

        public static class Factories
        {
            public static SupplierResponseView<T> CreateResponseView(IEnumerable<T> content)
            {
                return new SupplierResponseView<T>(content);
            }
        }
    }
}
