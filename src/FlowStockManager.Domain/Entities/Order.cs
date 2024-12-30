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

        private Order() { }

        private Order(Client client)
        {
            Id = Guid.NewGuid();
            ClientId = client.Id;
            OrderDate = DateTime.UtcNow;
            OrderStatus = OrderStatus.Pending;
            OrderProducts = new List<OrderProduct>();
        }

        public static class Factories
        {
            public static Order NewOrder(Client client)
            {
                return new Order(client);
            }
        }

        public void UpdateOrderStatusForProcessed()
        {
            OrderStatus = OrderStatus.Processed;
        }

        public void UpdateOrderStatus(OrderStatus status)
        {
            OrderStatus = status;
        }

        public void AddOrderProducts(IEnumerable<OrderProduct> orderProducts)
        {
            foreach (var item in orderProducts)
            {
                OrderProducts.Add(item);
            }
        }

        public void UpdateOrder(Order order)
        {
            OrderStatus = order.OrderStatus;
        }
    }
}
