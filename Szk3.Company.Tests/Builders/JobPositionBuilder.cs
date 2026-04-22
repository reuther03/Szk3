namespace Szk3.Company.Tests.Builders;

using Bogus;
using Domain.Entities.JobPosition;

public class JobPositionBuilder
{
    private readonly Faker _faker = new();

    private readonly List<PositionRate> _rates = new();
    private readonly List<PositionRequirement> _requirements = new();

    private string _name = "Software Developer";
    private string? _code = "DEV-01";
    private bool _isActive = true;


    public JobPositionBuilder WithId(int id)
    {
        return this;
    }

    public JobPositionBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public JobPositionBuilder WithCode(string? code)
    {
        _code = code;
        return this;
    }

    public JobPositionBuilder WithIsActive(bool isActive)
    {
        _isActive = isActive;
        return this;
    }

    public JobPositionBuilder Active()
    {
        _isActive = true;
        return this;
    }

    public JobPositionBuilder Inactive()
    {
        _isActive = false;
        return this;
    }

    public JobPositionBuilder WithDefaults(string? name = null, string? code = "DEV-01", bool isActive = true)
    {
        _name = string.IsNullOrWhiteSpace(name) ? "Software Developer" : name;
        _code = code;
        _isActive = isActive;
        return this;
    }

    public JobPositionBuilder WithRate(PositionRate rate)
    {
        _rates.Add(rate);
        return this;
    }

    public JobPositionBuilder WithRequirement(PositionRequirement requirement)
    {
        _requirements.Add(requirement);
        return this;
    }

    public JobPosition Build()
    {
        var entity = new JobPosition(_name, _code, _isActive);

        foreach (var rate in _rates)
        {
            entity.AddRate(rate);
        }

        foreach (var requirement in _requirements)
        {
            entity.AddRequirement(requirement);
        }

        return entity;
    }
}