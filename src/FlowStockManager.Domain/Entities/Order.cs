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

        public virtual IEnumerable<Product> Products { get; private set; }

        [Required]
        public Guid ProductsId { get; private set; }

        public DateTime OrderDate { get; private set; }

        public OrderStatus OrderStatus { get; private set; }

        public static class Factories
        {
            public static Order NewOrder(Client client, IEnumerable<Product> products)
            {
                return new Order(client, products);
            }
        }

        private Order(Client client, IEnumerable<Product> products)
        {
            Id = Guid.NewGuid();
            Client = client;
            Products = products;
            OrderDate = DateTime.Now;
            OrderStatus = OrderStatus.Pending;
        }
    }
}
