using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;
using Szk3.Company.Domain.Entities.Company;

namespace Szk3.Company.Application.Company.AddCompanyAddress;

public sealed class AddCompanyAddressCommandHandler : IRequestHandler<AddCompanyAddressCommand, int>
{
    private readonly ICompanyContext _companyContext;

    public AddCompanyAddressCommandHandler(ICompanyContext companyContext)
    {
        _companyContext = companyContext;
    }

    public async Task<int> Handle(AddCompanyAddressCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyContext.Companies
            .Include(x => x.Addresses)
            .FirstOrDefaultAsync(x => x.Id == request.CompanyId, cancellationToken);

        if (company is null)
            throw new InvalidOperationException($"Company with id '{request.CompanyId}' not found.");

        var address = new CompanyAddress(
            request.Street.Trim(),
            request.BuildingNumber.Trim(),
            request.ApartmentNumber?.Trim(),
            request.PostalCode.Trim(),
            request.City.Trim(),
            request.Country.Trim());

        company.AddAddress(address);
        await _companyContext.SaveChangesAsync(cancellationToken);

        return address.Id;
    }
}