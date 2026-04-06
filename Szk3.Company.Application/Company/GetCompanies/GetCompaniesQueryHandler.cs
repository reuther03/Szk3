using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;
using Szk3.Company.Application.Company.Models;

namespace Szk3.Company.Application.Company.GetCompanies;

public class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery, List<CompanyListDto>>
{
    private readonly ICompanyContext _companyContext;

    public GetCompaniesQueryHandler(ICompanyContext companyContext)
    {
        _companyContext = companyContext;
    }


    public async Task<List<CompanyListDto>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companies = await _companyContext.CompanyQuery
            .Select(x => new CompanyListDto
            {
                Id = x.Id,
                Name = x.Name,
                ShortName = x.ShortName,
                NIP = x.NIP
            })
            .ToListAsync(cancellationToken);

        return companies;
    }
}