namespace Szk3.Country.Application.Country.Models;

public sealed class CountryDetailsDto : CountryDto
{
    public List<CityDto> Cities { get; init; } = [];
}
