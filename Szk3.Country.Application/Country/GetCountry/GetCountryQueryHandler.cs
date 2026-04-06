using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Country.Application.Common;
using Szk3.Country.Application.Country.Models;

namespace Szk3.Country.Application.Country.GetCountry;

public sealed class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, CountryDetailsDto?>
{
    private readonly ICountryContext _countryContext;

    public GetCountryQueryHandler(ICountryContext countryContext)
    {
        _countryContext = countryContext;
    }

    public async Task<CountryDetailsDto?> Handle(GetCountryQuery request, CancellationToken cancellationToken)
    {
        var country = await _countryContext.CountryQuery
            .Where(x => x.Id == request.Id)
            .Select(x => new CountryDetailsDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                IsActive = x.IsActive,
                Cities = x.Cities
                    .Select(c => new CityDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        IsActive = c.IsActive
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);

        return country;
    }
}