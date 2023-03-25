using Onix.Application.Utilities.Result;
using Onix.Domain.Entities.Common;
using System.Linq.Expressions;

namespace Onix.Application.Repositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> AsQueryable();

        Task<IEnumerable<TEntity>> GetAllAsync(bool noTracking = true);

        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter, bool noTracking = true
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            , params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetByIdAsync(Guid id, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
    }
}
