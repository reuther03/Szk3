using Microsoft.Extensions.DependencyInjection;
using Szk3.Company.Application.Common;

namespace Szk3.Company.Infra
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddCompanyInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<CompanyDbContext>();

            services.AddScoped<ICompanyContext>(provider => provider.GetRequiredService<CompanyDbContext>());

            return services;
        }
    }
}