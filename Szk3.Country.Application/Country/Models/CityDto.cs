namespace Szk3.Country.Application.Country.Models;

public sealed class CityDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public bool IsActive { get; init; }
}
