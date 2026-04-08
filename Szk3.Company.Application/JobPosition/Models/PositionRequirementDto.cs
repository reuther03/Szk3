namespace Szk3.Company.Application.JobPosition.Models;

public class PositionRequirementDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
}