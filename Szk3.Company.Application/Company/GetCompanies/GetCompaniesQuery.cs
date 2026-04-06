using MediatR;
using Szk3.Company.Application.Company.Models;

namespace Szk3.Company.Application.Company.GetCompanies;

public class GetCompaniesQuery : IRequest<List<CompanyListDto>>;