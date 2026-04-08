using System.Net.Mime;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Szk3.Common.Infra;
using Szk3.Company.Application.Common;
using Szk3.Company.Domain.Entities.JobPosition;

namespace Szk3.Company.Infra;

public class CompanyDbContext : PlatformDbContext, ICompanyContext
{
    private readonly IConfiguration _configuration;

    public CompanyDbContext(IConfiguration configuration, DbContextOptions<CompanyDbContext> options)
        : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Domain.Entities.Company.Company> Companies { get; set; } = null!;
    public DbSet<JobPosition> JobPositions { get; set; } = null!;

    public IQueryable<JobPosition> JobPositionQuery => Set<JobPosition>().AsNoTracking().AsQueryable();

    public IQueryable<Domain.Entities.Company.Company> CompanyQuery => Set<Domain.Entities.Company.Company>().AsNoTracking().AsQueryable();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"server=localhost\SQLEXPRESS;database=CompanyDb;trusted_connection=true;TrustServerCertificate=True;");

    }
}