using MediatR;
using Microsoft.EntityFrameworkCore;
using Szk3.Company.Application.Common;

namespace Szk3.Company.Application.JobPosition.DeleteJobPosition;

public class DeleteJobPositionCommandHandler : IRequestHandler<DeleteJobPositionCommand, Unit>
{
    private readonly ICompanyContext _companyContext;

    public DeleteJobPositionCommandHandler(ICompanyContext companyContext)
    {
        _companyContext = companyContext;
    }

    public async Task<Unit> Handle(DeleteJobPositionCommand request, CancellationToken cancellationToken)
    {
        var jobPosition = await _companyContext.JobPositionQuery
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (jobPosition is null)
        {
            throw new Exception($"Job position with id {request.Id} not found.");
        }

        _companyContext.Delete(jobPosition);
        await _companyContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}