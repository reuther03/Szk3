namespace Szk3.Country.Application.Country.Models;

public sealed class CityDto
{
    public int Id  { get; set; }
    public required string Name { get; set; }
    public bool IsActive { get; set; }
}