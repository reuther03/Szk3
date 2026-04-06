using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Szk3.Common.Infra;
using Szk3.Country.Domain.Entities.Countries;

namespace Szk3.Country.Infra
{
    public class CountryDbContext : PlatformDbContext, Application.Common.ICountryContext
    {
        private readonly IConfiguration _configuration;

        public CountryDbContext(IConfiguration configuration, DbContextOptions<CountryDbContext> options)
     : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Szk3.Country.Domain.Entities.Countries.Country> Countries { get; set; } = null!;

        public IQueryable<City> CityQuery => Set<City>().AsNoTracking().AsQueryable();

        public IQueryable<Szk3.Country.Domain.Entities.Countries.Country> CountryQuery => Set<Szk3.Country.Domain.Entities.Countries.Country>().AsNoTracking().AsQueryable();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"server=localhost;database=country-dev;trusted_connection=true;TrustServerCertificate=True;", x => x.MigrationsHistoryTable("__EFMigrationsHistory", DbConst.SCHEMA_NAME));
           
        }
    }
}
