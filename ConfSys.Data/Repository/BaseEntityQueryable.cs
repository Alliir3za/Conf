#nullable disable
using ConfSys.Shared.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;

namespace ConfSys.Data.Repository;

public class BaseEntityQueryable<TEntity> : IOrderedQueryable<TEntity> where TEntity : class, IEntity
{
    protected readonly DbSet<TEntity> _entity;

    public Type ElementType => typeof(TEntity);

    public Expression Expression { get; set; }

    public IQueryProvider Provider { get; }


    public BaseEntityQueryable(DbSet<TEntity> entity)
    {
        _entity = entity;
        Expression = entity.AsQueryable().Expression;
        Provider = entity.AsQueryable().Provider;
    }

    public IEnumerator<TEntity> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}