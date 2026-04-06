using Szk3.Country.Domain.Entities.Countries;

namespace Szk3.Country.Application.Common;

public interface IQueryContext
{
    IQueryable<City> CityQuery { get; }

    IQueryable<Szk3.Country.Domain.Entities.Countries.Country> CountryQuery { get; }

}
