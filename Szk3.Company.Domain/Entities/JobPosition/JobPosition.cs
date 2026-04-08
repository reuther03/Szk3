using Szk3.Common.Domain.Entities;

namespace Szk3.Company.Domain.Entities.JobPosition;

public class JobPosition : AggregateRoot<int>
{
    protected JobPosition()
    {
    }

    public JobPosition(string name, string? code = null, bool isActive = true)
    {
        Name = name;
        Code = code;
        IsActive = isActive;
    }

    public string Name { get; private set; } = null!;
    public string? Code { get; private set; }
    public bool IsActive { get; private set; }

    private readonly List<PositionRate> _rates = new();
    public IReadOnlyCollection<PositionRate> Rates => _rates;

    private readonly List<PositionRequirement> _requirement = new();
    public IReadOnlyCollection<PositionRequirement> Requirement => _requirement;

    public void AddRate(PositionRate rate)
    {
        if (_rates.Contains(rate))
            throw new InvalidOperationException("Rate already exists for this position.");

        _rates.Add(rate);
    }

    public void AddRequirement(PositionRequirement requirement)
    {
        if (_requirement.Contains(requirement))
            throw new InvalidOperationException("Requirement already exists for this position.");

        _requirement.Add(requirement);
    }


    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}