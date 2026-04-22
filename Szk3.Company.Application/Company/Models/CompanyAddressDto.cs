namespace Szk3.Company.Application.Company.Models;

public class  CompanyAddressDto
{
    public int Id { get; init; }
    public required string Street { get; init; }
    public required string BuildingNumber { get; init; }
    public string? ApartmentNumber { get; init; }
    public required string PostalCode { get; init; }
    public required string City { get; init; }
    public int CountryExternalId { get; init; }
    public required string CountryDisplay { get; init; }
    public bool IsActive { get; init; }
}