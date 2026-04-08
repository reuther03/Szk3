using Szk3.Company.Domain.Entities.JobPosition;

namespace Szk3.Company.Application.Common;

public interface IQueryContext
{
    IQueryable<Domain.Entities.JobPosition.JobPosition> JobPositionQuery { get; }

    IQueryable<Domain.Entities.Company.Company> CompanyQuery { get; }
}