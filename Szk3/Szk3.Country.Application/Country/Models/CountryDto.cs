namespace Szk3.Country.Application.Country.Models;

public sealed class CountryDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public string Code { get; init; } = null!;
    public bool IsActive { get; init; }
    public List<CityDto> Cities { get; init; } = [];
}