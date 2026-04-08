using MediatR;
using Szk3.Company.Application.JobPosition.Models;

namespace Szk3.Company.Application.JobPosition.GetJobPosition;

public record GetJobPositionQuery(int Id) : IRequest<JobPositionDetailsDto>;