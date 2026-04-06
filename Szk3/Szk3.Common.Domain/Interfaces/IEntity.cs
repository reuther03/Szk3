namespace Szk3.Common.Domain.Interfaces;

public interface IEntity
{
    void SetCreationDate(DateTime dateTime);

    void SetUpdateDate(DateTime dateTime);
}
