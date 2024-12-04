using FlowStockManager.Domain.Entities.Enums;
using FlowStockManager.Infra.CrossCutting.DTOs.Products;

namespace FlowStockManager.Infra.CrossCutting.DTOs.Orders
{
    public record OrderDto
    {
        public Guid Id { get; init; }
        public Guid ClientId { get; init; }
        public List<ProductDto> Products { get; init; }
        public DateTime OrderDate { get; init; }
        public OrderStatus OrderStatus { get; init; }
    }
}
