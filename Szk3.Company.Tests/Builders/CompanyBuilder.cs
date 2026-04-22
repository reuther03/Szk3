namespace Szk3.Company.Tests.Builders;

using Bogus;
using Szk3.Company.Domain.Entities.Company;

public class CompanyBuilder
{
    private readonly Faker _faker = new();

    private readonly List<CompanyAddress> _addresses = new();
    private readonly List<CompanyOwner> _owners = new();

    private string _name = "Tech Solutions Sp. z o.o.";
    private string _shortName = "Tech Solutions";
    private string? _nip = "1234567890";
    private string? _regon = "123456789";
    private string? _kraz = "1234";
    private string? _krs = "0000123456";

    public CompanyBuilder WithId(int id)
    {
        return this;
    }

    public CompanyBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CompanyBuilder WithShortName(string shortName)
    {
        _shortName = shortName;
        return this;
    }

    public CompanyBuilder WithNip(string? nip)
    {
        _nip = nip;
        return this;
    }

    public CompanyBuilder WithRegon(string? regon)
    {
        _regon = regon;
        return this;
    }

    public CompanyBuilder WithKraz(string? kraz)
    {
        _kraz = kraz;
        return this;
    }

    public CompanyBuilder WithKrs(string? krs)
    {
        _krs = krs;
        return this;
    }

    public CompanyBuilder WithDefaults(
        string? name = null,
        string? shortName = null,
        string? nip = "1234567890",
        string? regon = "123456789")
    {
        _name = string.IsNullOrWhiteSpace(name) ? "Tech Solutions Sp. z o.o." : name;
        _shortName = string.IsNullOrWhiteSpace(shortName) ? "Tech Solutions" : shortName;
        _nip = nip;
        _regon = regon;
        return this;
    }

    public CompanyBuilder WithAddress(CompanyAddress address)
    {
        _addresses.Add(address);
        return this;
    }

    public CompanyBuilder WithOwner(CompanyOwner owner)
    {
        _owners.Add(owner);
        return this;
    }

    public CompanyBuilder WithRandomData()
    {
        _name = _faker.Company.CompanyName();
        _shortName = _name.Substring(0, Math.Min(_name.Length, 10));

        return this;
    }

    public Company Build()
    {
        var entity = new Company(_name, _shortName, _nip, _regon, _kraz, _krs);

        foreach (var address in _addresses)
        {
            entity.AddAddress(address);
        }

        foreach (var owner in _owners)
        {
            entity.AddOwner(owner);
        }

        return entity;
    }
}