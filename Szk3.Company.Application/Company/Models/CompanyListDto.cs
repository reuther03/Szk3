namespace Szk3.Company.Application.Company.Models;

public class CompanyListDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string ShortName { get; init; }
    public string? NIP { get; init; }
}