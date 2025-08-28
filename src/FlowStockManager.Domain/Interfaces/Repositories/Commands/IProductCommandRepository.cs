using FlowStockManager.Domain.Entities;

namespace FlowStockManager.Domain.Interfaces.Repositories.Commands
{
    public interface IProductCommandRepository : IBaseCommandRepository<Product, string>
    {
        void Update(IEnumerable<Product> products);
    }
}
