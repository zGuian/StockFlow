using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Repositories.Commands
{
    public interface ISupplierCommandRepository : IBaseCommandRepository<Supplier, Guid>
    {
    }
}
