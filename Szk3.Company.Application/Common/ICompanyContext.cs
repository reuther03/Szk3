using Microsoft.EntityFrameworkCore;
using Szk3.Common.Application.Interfaces;
using Szk3.Company.Domain.Entities.JobPosition;

namespace Szk3.Company.Application.Common;

public interface ICompanyContext : IQueryContext, IContext
{
    DbSet<Domain.Entities.Company.Company> Companies { get; }
}