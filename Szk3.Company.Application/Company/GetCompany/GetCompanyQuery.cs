using MediatR;
using Szk3.Company.Application.Company.Models;

namespace Szk3.Company.Application.Company.GetCompany;

public sealed record GetCompanyQuery(int Id) : IRequest<CompanyDetailsDto>;