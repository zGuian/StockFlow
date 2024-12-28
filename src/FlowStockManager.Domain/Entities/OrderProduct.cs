namespace FlowStockManager.Domain.Entities
{
    public class OrderProduct
    {
        public Guid OrderId { get; private set; }
        public Order Orders { get; private set; } = null!;
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; } = null!;
        public int ProductQuantity { get; private set; }

        private OrderProduct() { }

        private OrderProduct(Order order, Product product, int productQuantity)
        {
            OrderId = order.Id;
            Orders = order;
            ProductId = product.Id;
            Product = product;
            ProductQuantity = productQuantity;
        }

        public static class Factories
        {
            public static IEnumerable<OrderProduct> NewOrderProduct(Order order, IEnumerable<Product> products, IEnumerable<int> productQuantity)
            {
                return products.Zip(productQuantity, (products, qttProduct) =>
                    new OrderProduct(order, products, qttProduct));
            }

            public static IEnumerable<OrderProduct> NewOrderProduct(Order order, IEnumerable<Tuple<Product, int>> tuple)
            {
                var orderProduct = new List<OrderProduct>();
                foreach (var item in tuple)
                {
                    orderProduct.Add(new OrderProduct(order, item.Item1, item.Item2));                    
                }
                return orderProduct;
            }
        }

        public void AddProduct(Product existingProduct)
        {
            Product = existingProduct;
        }

        public void UpdateOrder(Order order)
        {
            Orders = order;
        }

        public void UpdateOrderProduct(Product product, int quantityProduct)
        {
            product.ConsumeProduct(quantityProduct);
            Product = product;
        }

        public void AddOrderAndProduct(Order order, Product product)
        {
            Orders = order;
            Product = product;
        }
    }
}
