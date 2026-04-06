using MediatR;

namespace Szk3.Company.Application.Company.CreateCompany;

public sealed record CreateCompanyCommand(
    string Name,
    string ShortName,
    string? NIP,
    string? REGON,
    string? KRAZ,
    string? KRS) : IRequest<int>;