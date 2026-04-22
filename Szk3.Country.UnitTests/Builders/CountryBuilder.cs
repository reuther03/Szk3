using Bogus;

namespace Szk3.Country.UnitTests.Builders;

public class CountryBuilder
{
    private readonly List<CitySpec> _citySpecs = new();
    private readonly Faker _faker;

    private string _name = "Poland";
    private string _code = "PL";
    private bool _isActive = true;

    public CountryBuilder WithId(int id)
    {
        return this;
    }

    public CountryBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CountryBuilder WithCode(string code)
    {
        _code = code;
        return this;
    }

    public CountryBuilder WithIsActive(bool isActive)
    {
        _isActive = isActive;
        return this;
    }

    public CountryBuilder Active()
    {
        _isActive = true;
        return this;
    }

    public CountryBuilder Inactive()
    {
        _isActive = false;
        return this;
    }

    public CountryBuilder WithDefaults(string? name, string code = "PL", bool isActive = true)
    {
        _name = string.IsNullOrWhiteSpace(name) ? "Poland" : name;
        _code = code;
        _isActive = isActive;
        return this;
    }

    public CountryBuilder WithCity(string name, bool isActive = true)
    {
        _citySpecs.Add(new CitySpec(name, isActive));
        return this;
    }

    public CountryBuilder WithCities(params string[] cityNames)
    {
        foreach (var cityName in cityNames)
        {
            _citySpecs.Add(new CitySpec(cityName, true));
        }

        return this;
    }

    public CountryBuilder WithRandomCities(int count)
    {
        for (var i = 0; i < count; i++)
        {
            _citySpecs.Add(new CitySpec(_faker.Name.FirstName(), true));
        }

        return this;
    }

    public Domain.Entities.Countries.Country Build()
    {
        var entity = new Domain.Entities.Countries.Country(_name, _code, _isActive);
        foreach (var citySpec in _citySpecs)
        {
            entity.AddCity(citySpec.Name, citySpec.IsActive);
        }
        return entity;
    }


    private sealed record CitySpec(string Name, bool IsActive);
}