using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;
using Szk3.Company.Domain.Entities.Company;
using Szk3.Company.Domain.Entities.JobPosition;

namespace Szk3.Company.Application.JobPosition.AddPositionRate;

public class AddPositionRateCommandHandler : IRequestHandler<AddPositionRateCommand, int>
{
    private readonly ICompanyContext _companyContext;

    public AddPositionRateCommandHandler(ICompanyContext companyContext)
    {
        _companyContext = companyContext;
    }

    public async Task<int> Handle(AddPositionRateCommand request, CancellationToken cancellationToken)
    {
        var jobPosition = await _companyContext.JobPositions
            .Include(x => x.Rates)
            .FirstOrDefaultAsync(x => x.Id == request.JobPositionId, cancellationToken);

        if (jobPosition is null)
            throw new InvalidOperationException($"Job position with id '{request.JobPositionId}' not found.");

        var positionRate = new PositionRate(
            request.Amount,
            request.Currency.Trim(),
            request.RateType);

        jobPosition.AddRate(positionRate);
        await _companyContext.SaveChangesAsync(cancellationToken);

        return positionRate.Id;
    }
}