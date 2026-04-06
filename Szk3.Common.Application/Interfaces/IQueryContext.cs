using System.Linq.Expressions;


namespace Szk3.Common.Application.Interfaces;

public interface IQueryContext
{
    Task<TEntity?> FirstOrDefaultAsync<TEntity>(
        Expression<Func<TEntity, bool>> selector,
        CancellationToken cancellationToken)
        where TEntity : class;

    Task<TEntity> FirstAsync<TEntity>(Expression<Func<TEntity, bool>> selector, CancellationToken cancellationToken)
        where TEntity : class;

    Task<TEntity?> FindAsync<TEntity, TId>(TId id, CancellationToken cancellationToken)
        where TEntity : class
        where TId : struct;

    Task<bool> AnyAsync<TEntity>(
        Expression<Func<TEntity, bool>> selector,
        CancellationToken cancellationToken)
        where TEntity : class;
}
