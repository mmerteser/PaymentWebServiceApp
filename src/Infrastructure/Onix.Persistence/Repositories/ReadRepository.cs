using Microsoft.EntityFrameworkCore;
using Onix.Application.Repositories;
using Onix.Application.Utilities.Result;
using Onix.Domain.Entities.Common;
using Onix.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly OnixContext _context;

        public ReadRepository(OnixContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> AsQueryable() => Table.AsQueryable();

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            var query = Table.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            query = ApplyIncludes(query, includes);

            if (noTracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            var query = Table.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            query = ApplyIncludes(query, includes);

            if (noTracking)
                query = query.AsNoTracking();

            return query;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(bool noTracking = true)
        {
            var query = Table.AsQueryable();
            if (noTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            T found = await Table.FindAsync(id);

            if (found is null)
                return null;

            if (noTracking)
                _context.Entry(found).State = EntityState.Detached;

            foreach (var include in includes)
            {
                _context.Entry(found).Reference(include).Load();
            }

            return found;
        }

        public virtual async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> filter, bool noTracking = true, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Table;

            if (filter != null)
                query = query.Where(filter);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (orderBy != null)
                query = orderBy(query);

            if (noTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Table;

            if (filter != null)
                query = query.Where(filter);

            if (noTracking)
                query = query.AsNoTracking();

            query = ApplyIncludes(query, includes);

            return await query.SingleOrDefaultAsync();
        }

        private IQueryable<T> ApplyIncludes(IQueryable<T> query, Expression<Func<T, object>>[] includes)
        {
            if (includes != null)
            {
                foreach (var includeItem in includes)
                {
                    query = query.Include(includeItem);
                }
            }

            return query;
        }


    }
}
