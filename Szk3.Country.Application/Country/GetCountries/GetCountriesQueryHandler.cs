using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Country.Application.Common;
using Szk3.Country.Application.Country.Models;

namespace Szk3.Country.Application.Country.GetCountries
{
    public sealed class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, List<CountryDto>>
    {
        private readonly ICountryContext _countryContext;

        public GetCountriesQueryHandler(ICountryContext countryContext)
        {
            _countryContext = countryContext;
        }

        public async Task<List<CountryDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = await _countryContext.CountryQuery
                .Select(x => new CountryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    IsActive = x.IsActive                  
                })
                .ToListAsync(cancellationToken);

            return countries;
        }
    }
}