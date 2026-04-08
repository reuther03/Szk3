using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;
using Szk3.Company.Application.Company.Models;
using Szk3.Company.Application.JobPosition.Models;

namespace Szk3.Company.Application.JobPosition.GetJobPositions;

public class GetJobPositionsQueryHandler : IRequestHandler<GetJobPositionsQuery, List<JobPositionDto>>
{
    private readonly ICompanyContext _companyContext;

    public GetJobPositionsQueryHandler(ICompanyContext companyContext)
    {
        _companyContext = companyContext;
    }

    public async Task<List<JobPositionDto>> Handle(GetJobPositionsQuery request, CancellationToken cancellationToken)
    {
        var jobPositions = await _companyContext.JobPositionQuery
            .Select(x => new JobPositionDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                IsActive = x.IsActive,
            }).ToListAsync(cancellationToken);

        return jobPositions;
    }
}