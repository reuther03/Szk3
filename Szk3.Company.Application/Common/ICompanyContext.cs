using Microsoft.EntityFrameworkCore;
using Szk3.Common.Application.Interfaces;

namespace Szk3.Company.Application.Common;

public interface ICompanyContext : IQueryContext, IContext
{
    DbSet<Domain.Entities.Company.Company> Companies { get; }
    DbSet<Domain.Entities.JobPosition.JobPosition> JobPositions { get; }
}