using ConfSys.Domain;
using Microsoft.EntityFrameworkCore;

namespace ConfSys.Data;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly DbSet<TEntity> _entities;
    public GenericRepository(ConfSysDbContext dbContext) => _entities = dbContext.Set<TEntity>();

    public async Task CreateAsync(TEntity model, CancellationToken token = default) => await _entities.AddAsync(model, token);

    public void Delete(TEntity model) => _entities.Remove(model);

    public async Task<TEntity> FindAsync(object id, CancellationToken token = default)
    {
        return await _entities.FindAsync(id, token);
    }
    public async Task<IEnumerable<TEntity>> GetAll() => await _entities.ToListAsync();

    public void Update(TEntity model) => _entities.Attach(model);
}
