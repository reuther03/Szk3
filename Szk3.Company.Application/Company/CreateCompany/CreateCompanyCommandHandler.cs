using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;

namespace Szk3.Company.Application.Company.CreateCompany;

public sealed class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, int>
{
    private readonly ICompanyContext _companyContext;

    public CreateCompanyCommandHandler(ICompanyContext companyContext)
    {
        _companyContext = companyContext;
    }

    public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var exists = await _companyContext.Companies.AnyAsync(x => x.Name == request.Name, cancellationToken);

        if (exists)
            throw new InvalidOperationException($"Company with name '{request.Name}' already exists.");

        var company = new Domain.Entities.Company.Company(
            request.Name.Trim(),
            request.ShortName.Trim(),
            request.NIP?.Trim(),
            request.REGON?.Trim(),
            request.KRAZ?.Trim(),
            request.KRS?.Trim());

        _companyContext.Add(company);
        await _companyContext.SaveChangesAsync(cancellationToken);

        return company.Id;
    }
}