namespace Szk3.Company.Application.Company.Models;

public class CompanyDetailsDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string ShortName { get; init; }
    public string? NIP { get; init; }
    public string? REGON { get; init; }
    public string? KRAZ { get; init; }
    public string? KRS { get; init; }
    public List<CompanyAddressDto> Addresses { get; init; } = [];
    public List<CompanyOwnerDto> Owners { get; init; } = [];
}