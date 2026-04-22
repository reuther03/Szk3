using Microsoft.Extensions.DependencyInjection;
using Szk3.Company.Application.Common;
using Szk3.Company.Infra.Services;

namespace Szk3.Company.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCompanyInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<CompanyDbContext>();

            services.AddScoped<ICompanyContext>(provider => provider.GetRequiredService<CompanyDbContext>());

            services.AddScoped<ICountryDataResolver, CountryDataResolver>();

            services.AddHttpClient("CountryApi",
                client =>
                    client.BaseAddress = new Uri("http://localhost:5094"));

            return services;
        }
    }
}