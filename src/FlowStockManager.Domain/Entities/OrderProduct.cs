namespace FlowStockManager.Domain.Entities
{
    public class OrderProduct
    {
        public Guid OrderId { get; set; }
        public Order Orders { get; set; } = null!;
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public static class Factories
        {
            public static IEnumerable<OrderProduct> NewOrderProduct(Order order, IEnumerable<Product> products)
            {
                var orderProducts = products.Select(p => new OrderProduct(order, p));
                foreach (var item in orderProducts)
                {
                    item.Orders = order;
                }
                return orderProducts;
            }
        }

        private OrderProduct() { }

        public OrderProduct(Order order, Product product) 
        {
            OrderId = order.Id;
            Orders = order;
            ProductId = product.Id;
            Product = product;
        }
    }
}
