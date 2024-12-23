using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.DTOs.Clients
{
    public record ClientDto
    {
        public Guid Id;
        public string Name;
        public string Email;
        public string? Phone;
        public string DeliveryAddress;
        public bool IsActive;
        public ICollection<Order>? Orders;

        public ClientDto() { }
    }
}
