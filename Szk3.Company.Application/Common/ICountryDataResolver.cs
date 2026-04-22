namespace Szk3.Company.Application.Common;

public interface ICountryDataResolver
{
    Task<CountryResolveResult> ResolveAsync(int countryId, CancellationToken cancellationToken);
}

public sealed record CountryResolveResult(
    int Id,
    string Display);