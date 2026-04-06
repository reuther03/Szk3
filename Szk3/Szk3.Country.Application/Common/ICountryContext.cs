using Microsoft.EntityFrameworkCore;
using Szk3.Common.Application.Interfaces;

namespace Szk3.Country.Application.Common
{
    public interface ICountryContext : IQueryContext, IContext
    {
        DbSet<Szk3.Country.Domain.Entities.Countries.Country> Countries { get; }
    }
}
