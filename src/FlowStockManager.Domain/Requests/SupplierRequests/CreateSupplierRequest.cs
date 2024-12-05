using System.ComponentModel.DataAnnotations;

namespace FlowStockManager.Domain.Requests.SupplierRequests;

public record CreateSupplierRequest
{
    [MinLength(3), MaxLength(100)]
    [Required]
    public string Name { get; init; } = null!;

    public string? Contact { get; init; }

    [MaxLength(250)]
    public string? Address { get; init; }
}