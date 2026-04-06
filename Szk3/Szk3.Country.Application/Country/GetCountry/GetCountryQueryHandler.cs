using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Country.Application.Common;
using Szk3.Country.Application.Country.Models;

namespace Szk3.Country.Application.Country.GetCountry;

public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, CountryDto>
{
    private readonly ICountryContext _countryContext;

    public GetCountryQueryHandler(ICountryContext countryContext)
    {
        _countryContext = countryContext;
    }

    public async Task<CountryDto> Handle(GetCountryQuery request, CancellationToken cancellationToken)
    {
        var country = await _countryContext.Countries
            .Where(x => x.Id == request.Id)
            .Select(x => new CountryDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                IsActive = x.IsActive,
                Cities = x.Cities.Select(z => new CityDto
                {
                    Name = z.Name,
                    Id = z.Id,
                    IsActive = z.IsActive
                }).ToList()
            }).FirstAsync(cancellationToken);

        return country;
    }
}