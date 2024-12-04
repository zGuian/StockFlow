using FlowStockManager.Domain.Requests.OrderRequest.DtoRequest;
using System.ComponentModel.DataAnnotations;

namespace FlowStockManager.Domain.Requests.OrderRequest
{
    public record CreateOrderRequest
    {
        [Required]
        public Guid ClientId { get; init; }

        [Required]
        public IEnumerable<ProductDtoRequest> Products { get; init; } = null!;
    }
}
