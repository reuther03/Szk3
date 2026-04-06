
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Szk3.Common.Domain.Interfaces;
using System.Buffers.Binary;

namespace Szk3.Common.Domain.Entities;

public abstract class AggregateRoot<TId> : EntityBase<TId>, IAggregateRoot
       where TId : notnull
{
    [Timestamp]
    public byte[] Version { get; set; } = null!;

    public bool IsDeleted { get; protected set; }

    public virtual void Delete()
    {
        IsDeleted = true;
    }

    public ulong GetVersion()
    {
        return Version is null ? 0 : BinaryPrimitives.ReadUInt64BigEndian(Version);
    }
}
