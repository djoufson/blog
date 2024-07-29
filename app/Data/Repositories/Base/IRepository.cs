using System.Linq.Expressions;
using app.Domain.Base;

namespace app.Data.Repositories.Base;
public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
{
    IQueryable<TEntity> Query();
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken = default);
    Task<TEntity?> GetAsync(TId id, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
}
