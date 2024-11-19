namespace FlowStockManager.Infra.CrossCutting.DTOs.Products
{
    public record ProductDto(Guid Id, string Name, string? Description, decimal Price, int StockQuantity, int MinimalStockQuantity);
}
