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
            public static Order NewOrder(Client client)
            {
                return new Order(client);
            }
        }

        public static Order UpdateOrderStatus(Order order, OrderStatus status)
        {
            switch (order.OrderStatus)
            {
                case OrderStatus.Pending:
                    if (status == OrderStatus.Processed || status == OrderStatus.Canceled)
                    {
                        order.OrderStatus = status;
                    }
                    break;
                case OrderStatus.Processed:
                    if (status == OrderStatus.Concluded || status == OrderStatus.Canceled)
                    {
                        order.OrderStatus = status;
                    }
                    break;
                case OrderStatus.Concluded:
                    order.OrderStatus = OrderStatus.Concluded;
                    break;
                case OrderStatus.Canceled:
                    order.OrderStatus = OrderStatus.Canceled;
                    break;
                default:
                    throw new ErrorResponse("Status do pedido esta invalido");
            }
            return order;
        }

        public static void AddOrderProducts(Order order, IEnumerable<OrderProduct> orderProducts)
        {
            order.OrderProducts = orderProducts.ToList();
        }

        private Order() { }

        private Order(Client client)
        {
            Id = Guid.NewGuid();
            //ClientId = client.Id;
            Client = client;
            OrderDate = DateTime.UtcNow;
            OrderStatus = OrderStatus.Pending;
        }
    }
}
