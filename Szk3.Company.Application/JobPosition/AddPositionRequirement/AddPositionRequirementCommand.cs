using MediatR;

namespace Szk3.Company.Application.JobPosition.AddPositionRequirement;

public sealed record AddPositionRequirementCommand(
    int JobPositionId,
    string Name,
    string? Description
) : IRequest<int>;