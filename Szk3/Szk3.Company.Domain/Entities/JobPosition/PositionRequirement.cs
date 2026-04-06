using Szk3.Common.Domain.Entities;

namespace Szk3.Company.Domain.Entities.JobPosition;

public class PositionRequirement : EntityBase<int>
{

    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }

    protected PositionRequirement() { }

    public PositionRequirement(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}
