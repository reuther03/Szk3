using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Szk3.Company.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddCompanyApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}