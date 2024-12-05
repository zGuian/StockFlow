﻿namespace FlowStockManager.Domain.Entities
{
    public class OrderProduct
    {
        public Guid OrderId { get; private set; }
        public Order Orders { get; private set; } = null!;
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; } = null!;
        public int ProductQuantity { get; private set; }

        public static class Factories
        {
            public static IEnumerable<OrderProduct> NewOrderProduct(Order order, IEnumerable<Product> products, IEnumerable<int> productQuantity)
            {
                return products.Zip(productQuantity, (products, qttProduct) =>
                    new OrderProduct(order, products, qttProduct));
            }
        }

        public OrderProduct(Order order, Product product, int productQuantity)
        {
            OrderId = order.Id;
            Orders = order;
            ProductId = product.Id;
            Product = product;
            ProductQuantity = productQuantity;
        }

        public void AddProduct(Product existingProduct)
        {
            Product = existingProduct;
        }

        public static void UpdateOrder(IEnumerable<OrderProduct> orderProduct, Order order)
        {
            foreach (var item in orderProduct)
            {
                item.Orders = order;
            }
        }

        public static void UpdateOrderProduct(OrderProduct orderProduct, Product product, int quantityProduct)
        {
            Product.ConsumeProduct(product, quantityProduct);
            orderProduct.Product = product;
        }

        public static void AddOrderAndProduct(OrderProduct orderProduct, Order order, Product product)
        {
            orderProduct.Orders = order;
            orderProduct.Product = product;
        }

        private OrderProduct() { }


    }
}
