using MediatR;
using Szk3.Country.Application.Country.Models;

namespace Szk3.Country.Application.Country.GetCountry;

public record GetCountryQuery(int Id) : IRequest<CountryDto>;