using ConfSys.Shared.Core.Data;
using ConfSys.Shared.Core.Entity;

namespace ConfSys.Data.Repository;

public class GenericRepository<TEntity> : BaseEntityQueryable<TEntity>, IGenericRepo<TEntity> where TEntity : class, IEntity
{

    public GenericRepository(ConfSysDbContext dbContext)
      : base(dbContext.Set<TEntity>()) { }

    public void Add(TEntity entity) => _entity.Add(entity);

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default) => await _entity.AddAsync(entity, cancellationToken);

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) => await _entity.AddRangeAsync(entities, cancellationToken);

    public void Remove(TEntity entity) => _entity.Remove(entity);

    public void RemoveRange(IEnumerable<TEntity> entities) => _entity.RemoveRange(entities);

    public void Update(TEntity entity) => _entity.Update(entity);
}