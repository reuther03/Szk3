using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Szk3.Company.Application.Common;

namespace Szk3.Company.Infra.Services;

public class CountryDataResolver : ICountryDataResolver
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<CountryDataResolver> _logger;

    public CountryDataResolver(IHttpClientFactory httpClientFactory, ILogger<CountryDataResolver> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public async Task<CountryResolveResult> ResolveAsync(int countryId, CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient("CountryApi");
        var country = await client.GetFromJsonAsync<CountryApiDto>($"api/country/{countryId}", cancellationToken);

        if (country == null)
        {
            throw new ArgumentException($"Country {countryId} not found");
        }

        _logger.LogInformation($"Country {countryId} resolved");

        return new CountryResolveResult(country.Id, country.Name);
    }

    private sealed class CountryApiDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}