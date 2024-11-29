using FlowStockManager.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace FlowStockManager.Domain.Entities
{
    public class Order
    {
        [Required]
        public Guid Id { get; private set; }
        public virtual Client Client { get; private set; }
        [Required]
        public Guid ClientId { get; private set; }
        public virtual ICollection<OrderProduct>? Products { get; private set; }
        public DateTime OrderDate { get; private set; }
        public OrderStatus OrderStatus { get; private set; }

        public static class Factories
        {
            public static Order NewOrder(Client client)
            {
                return new Order(client);
            }
        }

        private Order() { }

        private Order(Client client)
        {
            Id = Guid.NewGuid();
            Client = client;
            OrderDate = DateTime.Now;
            OrderStatus = OrderStatus.Pending;
        }

        public static Order ProcessOrder(Order order)
        {
            if (order.OrderStatus == OrderStatus.Pending)
            {
                order.OrderStatus = OrderStatus.Processed;
                return order;
            }
            throw new InvalidOperationException("Status do pedido esta invalido");
        }
    }
}
