using System.ComponentModel.DataAnnotations;

namespace FlowStockManager.Domain.Requests.OrderRequest
{
    public record CreateOrderRequest
    {
        [Required]
        public Guid ClientId { get; private set; }

        [Required]
        public IEnumerable<Guid> ProductsId { get; private set; }
    }
}
