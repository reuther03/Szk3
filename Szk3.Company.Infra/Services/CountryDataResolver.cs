using Szk3.Company.Application.Common;

namespace Szk3.Company.Infra;

public class CountryDataResolver : ICountryDataResolver
{
    public Task<CountryResolveResult> ResolveAsync(int countryId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}