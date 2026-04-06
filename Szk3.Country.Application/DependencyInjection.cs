using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Szk3.Country.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddCountryApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
