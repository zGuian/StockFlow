using System.ComponentModel.DataAnnotations;

namespace FlowStockManager.Domain.Requests.SupplierRequests;

public record CreateSupplierRequest(
    [property: MinLength(3), MaxLength(100)]
    string Name, string? Contact,
    [property: MaxLength(250)] string? Address);