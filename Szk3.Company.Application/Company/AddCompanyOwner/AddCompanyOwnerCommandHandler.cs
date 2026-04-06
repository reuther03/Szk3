using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;
using Szk3.Company.Domain.Entities.Company;

namespace Szk3.Company.Application.Company.AddCompanyOwner;

public sealed class AddCompanyOwnerCommandHandler : IRequestHandler<AddCompanyOwnerCommand, int>
{
    private readonly ICompanyContext _companyContext;

    public AddCompanyOwnerCommandHandler(ICompanyContext companyContext)
    {
        _companyContext = companyContext;
    }

    public async Task<int> Handle(AddCompanyOwnerCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyContext.Companies
            .Include(x => x.Owners)
            .FirstOrDefaultAsync(x => x.Id == request.CompanyId, cancellationToken);

        if (company is null)
            throw new InvalidOperationException($"Company with id '{request.CompanyId}' not found.");

        var owner = new CompanyOwner(
            request.FullName.Trim(),
            request.PhoneNumber?.Trim(),
            request.Email?.Trim());

        company.AddOwner(owner);
        await _companyContext.SaveChangesAsync(cancellationToken);

        return owner.Id;
    }
}