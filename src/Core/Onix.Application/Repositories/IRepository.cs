using Microsoft.EntityFrameworkCore;
using Onix.Domain.Entities.Common;

namespace Onix.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        DbSet<TEntity> Table { get; }
    }
}
