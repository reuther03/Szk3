using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;
using Szk3.Company.Domain.Entities.Company;

namespace Szk3.Company.Application.Company.AddCompanyAddress;

public sealed class AddCompanyAddressCommandHandler : IRequestHandler<AddCompanyAddressCommand, int>
{
    private readonly ICompanyContext _companyContext;
    private readonly ICountryDataResolver _countryDataResolver;

    public AddCompanyAddressCommandHandler(ICompanyContext companyContext, ICountryDataResolver countryDataResolver)
    {
        _companyContext = companyContext;
        _countryDataResolver = countryDataResolver;
    }

    public async Task<int> Handle(AddCompanyAddressCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyContext.Companies
            .Include(x => x.Addresses)
            .FirstOrDefaultAsync(x => x.Id == request.CompanyId, cancellationToken);

        if (company is null)
            throw new InvalidOperationException($"Company with id '{request.CompanyId}' not found.");

        var country = await _countryDataResolver.ResolveAsync(request.CountryExternalId, cancellationToken);

        var address = new CompanyAddress(
            request.Street.Trim(),
            request.BuildingNumber.Trim(),
            request.ApartmentNumber?.Trim(),
            request.PostalCode.Trim(),
            request.City.Trim(),
            country.Id,
            country.Display,
            request.IsActive
        );

        company.AddAddress(address);
        await _companyContext.SaveChangesAsync(cancellationToken);

        return address.Id;
    }
}