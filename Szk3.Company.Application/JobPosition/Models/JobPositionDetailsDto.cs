namespace Szk3.Company.Application.JobPosition.Models;

public class JobPositionDetailsDto
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public string? Code { get; init; }
    public bool IsActive { get; init; }
    public List<PositionRateDto> Rates { get; init; } = [];
    public List<PositionRequirementDto> Requirements { get; init; } = [];
}