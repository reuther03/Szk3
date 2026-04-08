using MediatR;
using Szk3.Company.Application.JobPosition.Models;

namespace Szk3.Company.Application.JobPosition.GetJobPositions;

public class GetJobPositionsQuery : IRequest<List<JobPositionDto>>
{

}