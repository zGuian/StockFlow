using FlowStockManager.Domain.DTOs.Products;
using FlowStockManager.Domain.Entities.Enums;

namespace FlowStockManager.Domain.DTOs.Orders
{
    public record OrderDto
    {
        public Guid Id { get; init; }
        public Guid ClientId { get; init; }
        public IEnumerable<ProductDto> Products { get; init; } = null!;
        public DateTime OrderDate { get; init; }
        public OrderStatus OrderStatus { get; init; }
    }
}
