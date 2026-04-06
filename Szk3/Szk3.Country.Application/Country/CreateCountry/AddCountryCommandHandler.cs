using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Country.Application.Common;

namespace Szk3.Country.Application.Country.CreateCountry;

public class AddCountryCommandHandler : IRequestHandler<CreateCountryCommand, int>
{
    private readonly ICountryContext _countryContext;

    public AddCountryCommandHandler(ICountryContext countryContext)
    {
        _countryContext = countryContext;
    }

    public async Task<int> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var existingCountry = await _countryContext.Countries.AnyAsync(c => c.Code == request.Code, cancellationToken);

        if (existingCountry)
            throw new InvalidOperationException($"Country with code {request.Code} already exists.");

        var country = new Domain.Entities.Countries.Country
            (request.Name.Trim(), request.Code.Trim(), request.IsActive);

        _countryContext.Countries.Add(country);
        await _countryContext.SaveChangesAsync(cancellationToken);

        return country.Id;
    }
}