using System.ComponentModel.DataAnnotations;
using FlowStockManager.Domain.Validations;

namespace FlowStockManager.Domain.Requests.ProductRequests;

public record CreateProductRequest(
    [property: MinLength(3), MaxLength(100)]
    string Name,
    [property: MaxLength(500)] string? Description,
    [property: CheckPrice] decimal Price,
    int StockQuantity,
    [property: CheckMinimalStockQuantity] int MinimalStockQuantity,
    Guid SupplierId);