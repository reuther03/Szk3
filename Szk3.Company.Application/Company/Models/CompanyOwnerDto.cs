namespace Szk3.Company.Application.Company.Models;

public class CompanyOwnerDto
{
    public int Id { get; init; }
    public required string FullName { get; init; }
    public string? PhoneNumber { get; init; }
    public string? Email { get; init; }
}