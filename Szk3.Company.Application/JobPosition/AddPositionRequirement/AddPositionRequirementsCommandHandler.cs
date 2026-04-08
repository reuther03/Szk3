using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;
using Szk3.Company.Application.JobPosition.AddPositionRate;
using Szk3.Company.Domain.Entities.JobPosition;

namespace Szk3.Company.Application.JobPosition.AddPositionRequirement;

public class AddPositionRequirementsCommandHandler : IRequestHandler<AddPositionRequirementCommand, int>
{
    private readonly ICompanyContext _companyContext;

    public AddPositionRequirementsCommandHandler(ICompanyContext companyContext)
    {
        _companyContext = companyContext;
    }

    public async Task<int> Handle(AddPositionRequirementCommand request, CancellationToken cancellationToken)
    {
        var jobPosition = await _companyContext.JobPositions
            .Include(x => x.Requirement)
            .FirstOrDefaultAsync(x => x.Id == request.JobPositionId, cancellationToken);

        if (jobPosition is null)
            throw new InvalidOperationException($"Job position with id '{request.JobPositionId}' not found.");

        var positionRequirement = new PositionRequirement(
            request.Name,
            request.Description);

        jobPosition.AddRequirement(positionRequirement);
        await _companyContext.SaveChangesAsync(cancellationToken);

        return positionRequirement.Id;
    }
}