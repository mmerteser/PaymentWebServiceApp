using Onix.Application.Common.Result;
using Onix.Application.Utilities.Result;
using Onix.Domain.Entities.Common;
using System.Linq.Expressions;

namespace Onix.Application.Repositories
{
    public interface IWriteRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> AddAsync(TEntity entity);
        Task<bool> AddRangeAsync(IEnumerable<TEntity> entities);
        bool Add(TEntity entity);
        bool AddRange(IEnumerable<TEntity> entities);
        bool Remove(TEntity entity);
        bool RemoveRange(IEnumerable<TEntity> entities);
        bool Update(TEntity entity);
        bool AddOrUpdate(TEntity entity);
        Task<int> DeleteByIdsAsync(IEnumerable<Guid> ids);
        Task<int> BulkDeleteAsync(Expression<Func<TEntity, bool>> filter);
        int BulkDelete(Expression<Func<TEntity, bool>> filter);
        Task<int> BulkDeleteAsync(IEnumerable<TEntity> entities);
        bool BulkUpdate(IEnumerable<TEntity> entities);
        Task<int> SaveAsync();
    }
}
