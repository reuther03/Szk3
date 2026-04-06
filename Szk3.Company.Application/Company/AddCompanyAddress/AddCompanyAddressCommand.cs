using MediatR;

namespace Szk3.Company.Application.Company.AddCompanyAddress;

public sealed record AddCompanyAddressCommand(
    int CompanyId,
    string Street,
    string BuildingNumber,
    string? ApartmentNumber,
    string PostalCode,
    string City,
    string Country) : IRequest<int>;