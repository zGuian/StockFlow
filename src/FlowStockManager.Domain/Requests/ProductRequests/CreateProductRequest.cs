using System.ComponentModel.DataAnnotations;
using FlowStockManager.Domain.Validations;

namespace FlowStockManager.Domain.Requests.ProductRequests;

public record CreateProductRequest 
{
    [MinLength(3), MaxLength(100), Required]
    public string Name { get; init; } = null!;

    public string? Description { get; init; }

    [Required, CheckPrice]
    public decimal Price { get; init; }
    public int StockQuantity { get; init; }

    [Required]
    public Guid SupplierId { get; init; }
}