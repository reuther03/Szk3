using MediatR;
using Szk3.Country.Application.Country.Models;

namespace Szk3.Country.Application.Country.GetCountries;

public record GetCountriesQuery : IRequest<List<CountriesDto>>;