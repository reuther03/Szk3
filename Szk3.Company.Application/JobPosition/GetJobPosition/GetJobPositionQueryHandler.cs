using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;
using Szk3.Company.Application.Company.Models;
using Szk3.Company.Application.JobPosition.Models;

namespace Szk3.Company.Application.JobPosition.GetJobPosition;

public class GetJobPositionQueryHandler : IRequestHandler<GetJobPositionQuery, JobPositionDetailsDto>
{
    private readonly ICompanyContext _companyContext;

    public GetJobPositionQueryHandler(ICompanyContext companyContext)
    {
        _companyContext = companyContext;
    }

    public async Task<JobPositionDetailsDto> Handle(GetJobPositionQuery request, CancellationToken cancellationToken)
    {
        var jobPosition = await _companyContext.JobPositionQuery
            .Where(x => x.Id == request.Id)
            .Select(x => new JobPositionDetailsDto
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                IsActive = x.IsActive,
                Rates = x.Rates
                    .Select(r => new PositionRateDto
                    {
                        Id = r.Id,
                        Amount = r.Amount,
                        Currency = r.Currency,
                        RateType = r.RateType,
                    })
                    .ToList(),
                Requirements = x.Requirement
                    .Select(r => new PositionRequirementDto
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Description = r.Description,
                    })
                    .ToList()
            }).FirstOrDefaultAsync(cancellationToken);

        return jobPosition
            ?? throw new InvalidOperationException($"Job position with id '{request.Id}' not found.");
    }
}