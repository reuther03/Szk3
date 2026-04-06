using Szk3.Common.Domain.Interfaces;

namespace Szk3.Common.Application.Interfaces;

public interface IContext
{
    /// <summary>
    /// Adds an aggregate root entity to the context.
    /// </summary>
    /// <typeparam name="TAggregate">Aggregate type.</typeparam>
    /// <param name="entity">Entity.</param>
    void Add<TAggregate>(TAggregate entity)
      where TAggregate : class, IAggregateRoot;

    /// <summary>
    /// Deletes an aggregate root entity from the context.
    /// </summary>
    /// <typeparam name="TAggregate">Aggregate type.</typeparam>
    /// <param name="entity">Entity.</param>
    void Delete<TAggregate>(TAggregate entity)
    where TAggregate : class, IAggregateRoot;

    /// <summary>
    /// Saves changes made in the context to the underlying data store asynchronously.
    /// </summary>
    /// <param name="cancellationToken">CancellationToken.</param>
    /// <returns>Result.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
