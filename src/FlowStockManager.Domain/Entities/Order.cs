using FlowStockManager.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace FlowStockManager.Domain.Entities
{
    public class Order
    {
        [Required]
        public Guid Id { get; private set; }
        public virtual Client Client { get; private set; } = null!;
        [Required]
        public Guid ClientId { get; private set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; private set; } = null!;
        public DateTime OrderDate { get; private set; }
        public OrderStatus OrderStatus { get; private set; }

        public static class Factories
        {
            public static Order NewOrder(Client client, List<Product> products)
            {
                var order = new Order(client);
                var orderProducts = new List<OrderProduct>();
                foreach (var item in products)
                {
                    var op = new OrderProduct(order, item);
                    orderProducts.Add(op);
                }
                order.OrderProducts = orderProducts;
                return order;
            }
        }

        public static Order UpdateOrderStatus(Order order, OrderStatus status)
        {
            if (order.OrderStatus != OrderStatus.Pending)
            {
                order.OrderStatus = status;
                return order;
            }
            throw new InvalidOperationException("Status do pedido esta invalido");
        }

        private Order() { }

        private Order(Client client)
        {
            Id = Guid.NewGuid();
            ClientId = client.Id;
            Client = client;
            OrderDate = DateTime.UtcNow;
            OrderStatus = OrderStatus.Pending;
        }       
    }
}
