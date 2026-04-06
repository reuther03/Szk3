using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szk3.Country.Application.Common;

namespace Szk3.Country.Application.Country.AddCity;

public sealed class AddCityCommandHandler : IRequestHandler<AddCityCommand, int>
{
    private readonly ICountryContext _countryContext;

    public AddCityCommandHandler(ICountryContext countryContext)
    {
        _countryContext = countryContext;
    }

    public async Task<int> Handle(AddCityCommand request, CancellationToken cancellationToken)
    {
        var country = await _countryContext.Countries
            .FirstOrDefaultAsync(x => x.Id == request.CountryId, cancellationToken);

        if (country is null)
        {
            throw new InvalidOperationException($"Country with id '{request.CountryId}' does not exist.");
        }

        var cityName = request.Name.Trim();

        var cityExists = country.Cities.Any(x => x.Name.ToLower() == cityName.ToLower());

        if (cityExists)
        {
            throw new InvalidOperationException(
                $"City with name '{request.Name}' already exists in country '{country.Name}'.");
        }

        country.AddCity(cityName, request.IsActive);

        await _countryContext.SaveChangesAsync(cancellationToken);
        var addedCity = country.Cities.Last();
        return addedCity.Id;
    }
}
