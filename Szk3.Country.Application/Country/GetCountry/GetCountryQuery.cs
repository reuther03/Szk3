using MediatR;
using Szk3.Country.Application.Country.Models;

namespace Szk3.Country.Application.Country.GetCountry
{
    public sealed record GetCountryQuery(int Id) : IRequest<CountryDetailsDto?>;
}
