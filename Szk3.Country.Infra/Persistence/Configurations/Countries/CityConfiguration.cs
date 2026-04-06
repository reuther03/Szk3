using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities = Szk3.Country.Domain.Entities.Countries;
using Szk3.Country.Domain.Entities.Countries;

namespace Szk3.Country.Infra.Persistence.Configurations.Countries
{
    public class CityConfiguration : IEntityTypeConfiguration<Entities.City>
    {
        public void Configure(EntityTypeBuilder<Entities.City> builder)
        {
            builder.ToTable(nameof(City));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName(nameof(Entities.City.Name))
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.IsActive)
                .HasColumnName(nameof(Entities.City.IsActive))
                .IsRequired();

        }
    }
}
