using Szk3.Common.Domain.Entities;

namespace Szk3.Company.Domain.Entities.Company;

public class Company : AggregateRoot<int>
{
    private Company() { }

    public Company(string name, string shortName, string? nip, string? regon, string? kraz, string? krs)
    {
        Name = name;
        ShortName = shortName;
        NIP = nip;
        REGON = regon;
        KRAZ = kraz;
        KRS = krs;
    }

    public string Name { get; private set; } = null!;

    public string ShortName { get; private set; } = null!;

    public string? NIP { get; private set; }

    public string? REGON { get; private set; }

    public string? KRAZ { get; private set; }

    public string? KRS { get; private set; }

    private readonly List<CompanyAddress> _addresses = new();
    public IReadOnlyCollection<CompanyAddress> Addresses => _addresses;

    private readonly List<CompanyOwner> _owners = new();
    public IReadOnlyCollection<CompanyOwner> Owners => _owners;

    public void AddAddress(CompanyAddress address)
    {
        _addresses.Add(address);
    }

    public void AddOwner(CompanyOwner owner)
    {
        _owners.Add(owner);
    }

    public void UpdateCompanyData(
        string name,
        string shortName,
        string? nip,
        string? regon,
        string? kraz,
        string? krs)
    {
        Name = name;
        ShortName = shortName;
        NIP = nip;
        REGON = regon;
        KRAZ = kraz;
        KRS = krs;
    }
}
