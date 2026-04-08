using MediatR;
using Szk3.Company.Domain.Enums;

namespace Szk3.Company.Application.JobPosition.AddPositionRate;

public sealed record AddPositionRateCommand(
    int JobPositionId,
    decimal Amount,
    string Currency,
    RateType RateType) : IRequest<int>;