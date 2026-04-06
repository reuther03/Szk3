using MediatR;

namespace Szk3.Company.Application.Company.AddCompanyOwner;

public sealed record AddCompanyOwnerCommand(
    int CompanyId,
    string FullName,
    string? PhoneNumber,
    string? Email) : IRequest<int>;