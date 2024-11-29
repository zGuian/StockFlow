namespace FlowStockManager.Domain.Entities
{
    public class OrderProduct
    {
        public Guid OrderId { get; set; }
        public Order Orders { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        private OrderProduct() { }
    }
}
