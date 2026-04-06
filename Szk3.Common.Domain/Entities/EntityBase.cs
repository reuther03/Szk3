using Szk3.Common.Domain.Interfaces;

namespace Szk3.Common.Domain.Entities;

public abstract class EntityBase<TId> : IEntity
{
    public TId Id { get; protected set; } = default!;

    public DateTime CreatedOnUtc { get; protected set; }

    public DateTime? UpdatedOnUtc { get; protected set; }

    public bool IsNew => EqualityComparer<TId>.Default.Equals(Id, default);

    public void SetCreationDate(DateTime dateTime)
    {
        CreatedOnUtc = dateTime;
    }

    public void SetUpdateDate(DateTime dateTime)
    {
        UpdatedOnUtc = dateTime;
    }
}
