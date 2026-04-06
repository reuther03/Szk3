using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Szk3.Country.Application.Common;

namespace Szk3.Country.Infra
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddCountryInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<CountryDbContext>();

            services.AddScoped<ICountryContext>(sp => sp.GetRequiredService<CountryDbContext>());

            return services;
        }
    }
}
