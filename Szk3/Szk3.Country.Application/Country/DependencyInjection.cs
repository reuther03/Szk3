using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Szk3.Country.Application.Country;

public static class DependencyInjection
{
    public static IServiceCollection AddCountryApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });

        return services;
    }
}