namespace FlowStockManager.Domain.DTOs.Products
{
    public record ProductDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = null!;
        public string? Description { get; init; }
        public decimal Price { get; init; }
        public int StockQuantity { get; init; }
        public Guid SupplierId { get; init; }

        public ProductDto()
        {
        }
    }
}
