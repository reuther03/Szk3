namespace Szk3.Country.Application.Country.Models;

public record CountriesDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string Code { get; init; } = null!;
    public bool IsActive { get; init; }
}