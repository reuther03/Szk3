using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;

namespace Szk3.Company.Application.JobPosition.CreateJobPosition;

public sealed class CreateJobPositionCommandHandler : IRequestHandler<CreateJobPositionCommand, int>
{
    private readonly ICompanyContext _companyContext;

    public CreateJobPositionCommandHandler(ICompanyContext companyContext)
    {
        _companyContext = companyContext;
    }

    public async Task<int> Handle(CreateJobPositionCommand request, CancellationToken cancellationToken)
    {
        var exists = await _companyContext.JobPositions.AnyAsync(x => x.Name == request.Name, cancellationToken);

        if (exists)
            throw new InvalidOperationException($"Job position with name '{request.Name}' already exists.");

        var jobPosition = new Domain.Entities.JobPosition.JobPosition(
            request.Name.Trim(),
            request.Code?.Trim(),
            request.IsActive);

        _companyContext.Add(jobPosition);
        await _companyContext.SaveChangesAsync(cancellationToken);

        return jobPosition.Id;
    }
}
