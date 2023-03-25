using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Onix.Application.Repositories;
using Onix.Domain.Entities.Common;
using Onix.Persistence.Context;
using System.Linq.Expressions;

namespace Onix.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly OnixContext _context;

        public WriteRepository(OnixContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public bool Add(T entity)
        {
            var entityEntry = Table.Add(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddAsync(T entity)
        {
            var entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public bool AddOrUpdate(T entity)
        {
            if (!Table.Local.Any(i => EqualityComparer<Guid>.Default.Equals(i.Id, entity.Id)))
                _context.Update(entity);
            else
                _context.Add(entity);

            return true;
        }

        public bool AddRange(IEnumerable<T> entities)
        {
            if (entities != null && !entities.Any())
                return false;

            Table.AddRange(entities);
            return true;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            if (entities != null && !entities.Any())
                await Task.CompletedTask;

            await Table.AddRangeAsync(entities);
            return true;
        }


        public async Task<int> BulkDeleteAsync(Expression<Func<T, bool>> filter)
        {
            var result = await Table.Where(filter).ExecuteDeleteAsync();
            return result;
        }

        public int BulkDelete(Expression<Func<T, bool>> filter)
        {
            var result = Table.Where(filter).ExecuteDelete();
            return result;
        }

        public async Task<int> BulkDeleteAsync(IEnumerable<T> entities)
        {
            var result = await Table.Where(i => entities.Equals(i)).ExecuteDeleteAsync();
            return result;
        }

        public async Task<int> DeleteByIdsAsync(IEnumerable<Guid> ids)
        {
            var result = await Table.Where(i => ids.Equals(i.Id)).ExecuteDeleteAsync();
            return result;
        }

        public bool BulkUpdate(IEnumerable<T> entities)
        {
            foreach (var entityItem in entities)
            {
                Table.Attach(entityItem);
                _context.Entry(entityItem).State = EntityState.Modified;
            }
            return true;
        }


        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(IEnumerable<T> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public bool Update(T entity)
        {
            EntityEntry entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

    }
}
