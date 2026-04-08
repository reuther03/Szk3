using MediatR;

namespace Szk3.Company.Application.JobPosition.CreateJobPosition;

public sealed record CreateJobPositionCommand(
    string Name,
    string? Code,
    bool IsActive = true) : IRequest<int>;
