using FlowStockManager.Domain.Exceptions;
using FlowStockManager.Domain.Interfaces.Repositories.Commands;
using FlowStockManager.Domain.Interfaces.Repositories.Queries;
using FlowStockManager.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FlowStockManager.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity, UId> : IBaseQueryRepository<TEntity, UId>, 
        IBaseCommandRepository<TEntity, UId> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var result = await _dbSet.ToListAsync();
            if (result.Count < 1)
            {
                return [];
            }
            return result;
        }

        public virtual async Task<TEntity> GetByIdAsync(UId id)
        {
            return await _dbSet.FindAsync(id) ?? throw new Exception();
        }

        public virtual async Task RegisterAsync(TEntity obj)
        {
            try
            {
                var value = await _dbSet.AddAsync(obj);
                if (value.State.HasFlag(EntityState.Added))
                {
                    return;
                }
                throw new FailureRegisterDataBaseException("Não foi possivel adicionar valor ao banco");
            }
            catch (Exception)
            {
                // ADICIONAR LOG DE ERRO
                return;
            }
        }

        public virtual void Update(TEntity obj)
        {
            try
            {
                _dbSet.Update(obj);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task DeleteAsync(UId id)
        {
            var obj = await _dbSet.FindAsync(id);
            if (obj != null)
            {
                _dbSet.Remove(obj);
            }
        }
    }
}
