using System.ComponentModel.DataAnnotations;

namespace FlowStockManager.Domain.Entities
{
    public class Client
    {
        [Required]
        public Guid Id { get; private set; }

        [Required, MaxLength(40)]
        public string Name { get; private set; } = string.Empty;

        [Required, EmailAddress, MaxLength(40)]
        public string Email { get; private set; } = string.Empty;

        [MinLength(10), MaxLength(12)]
        public string? Phone { get; private set; }

        [Required, MinLength(10), MaxLength(200)]
        public string DeliveryAddress { get; private set; } = string.Empty;

        public virtual ICollection<Order>? Orders { get; private set; }

        public static class Factories
        {
            public static Client NewClient(string name, string email, string? phone, string deliveryAddress)
            {
                return new Client(name, email, phone, deliveryAddress);
            }
        }

        private Client() { }

        private Client(string name, string email, string? phone, string deliveryAddress)
        {
            Id = Guid.NewGuid();
            Name = name.ToLower().Trim();
            Email = email.ToLower().Trim();
            Phone = phone;
            DeliveryAddress = deliveryAddress.ToLower().Trim();
        }
    }
}
