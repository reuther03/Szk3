using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szk3.Country.Application.Country.Models;

namespace Szk3.Country.Application.Country.GetCountries
{
    public sealed record GetCountriesQuery() : IRequest<List<CountryDto>>;
}
