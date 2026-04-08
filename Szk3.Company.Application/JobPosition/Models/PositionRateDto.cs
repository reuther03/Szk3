using Szk3.Company.Domain.Enums;

namespace Szk3.Company.Application.JobPosition.Models;

public class PositionRateDto
{
    public int Id { get; init; }
    public decimal Amount { get; init; }
    public string Currency { get; init; } = null!;
    public RateType RateType { get; init; }
}