using MediatR;

namespace Szk3.Company.Application.JobPosition.DeleteJobPosition;

public record DeleteJobPositionCommand(int Id) : IRequest<Unit>;