namespace FlowStockManager.Domain.DTOs.Suppliers
{
    public class SupplierDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = null!;
        public string? Contact { get; init; }
        public string Address { get; init; } = null!;

        public SupplierDto()
        {
        }
    }
}
