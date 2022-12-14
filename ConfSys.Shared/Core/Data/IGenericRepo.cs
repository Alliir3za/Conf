using ConfSys.Shared.Core.Entity;

namespace ConfSys.Shared.Core.Data;

public interface IGenericRepo<TEntity> : IOrderedQueryable<TEntity> where TEntity : class, IEntity
{
    public void Add(TEntity entity);
    public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    public void Update(TEntity entity);
    public void Remove(TEntity entity);
    public void RemoveRange(IEnumerable<TEntity> entities);
}