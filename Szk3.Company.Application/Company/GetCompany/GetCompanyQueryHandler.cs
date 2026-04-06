using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;
using Szk3.Company.Application.Company.Models;

namespace Szk3.Company.Application.Company.GetCompany;

public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyDetailsDto?>
{
    private readonly ICompanyContext _companyContext;

    public GetCompanyQueryHandler(ICompanyContext companyContext)
    {
        _companyContext = companyContext;
    }

    public async Task<CompanyDetailsDto?> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        var company = await _companyContext.CompanyQuery
            .Where(x => x.Id == request.Id)
            .Select(x => new CompanyDetailsDto
            {
                Id = x.Id,
                Name = x.Name,
                ShortName = x.ShortName,
                NIP = x.NIP,
                REGON = x.REGON,
                KRAZ = x.KRAZ,
                KRS = x.KRS,
                Addresses = x.Addresses
                    .Select(a => new CompanyAddressDto
                    {
                        Id = a.Id,
                        Street = a.Street,
                        BuildingNumber = a.BuildingNumber,
                        ApartmentNumber = a.ApartmentNumber,
                        PostalCode = a.PostalCode,
                        City = a.City,
                        Country = a.Country,
                        IsActive = a.IsActive
                    })
                    .ToList(),
                Owners = x.Owners
                    .Select(o => new CompanyOwnerDto
                    {
                        Id = o.Id,
                        FullName = o.FullName,
                        PhoneNumber = o.PhoneNumber,
                        Email = o.Email
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);

        return company;
    }
}