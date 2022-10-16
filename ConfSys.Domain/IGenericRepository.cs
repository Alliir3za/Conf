namespace ConfSys.Domain;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task CreateAsync(TEntity model, CancellationToken token = default(CancellationToken));
    void Update(TEntity model);
    public void Delete(TEntity model);
    public Task<TEntity> FindAsync(object id, CancellationToken token = default(CancellationToken));
    Task<IEnumerable<TEntity>> GetAll();
}