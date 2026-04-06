using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities = Szk3.Country.Domain.Entities.Countries;
using Szk3.Country.Domain.Entities.Countries;

namespace Szk3.Country.Infra.Persistence.Configurations.Countries;

public class CountryConfiguration : IEntityTypeConfiguration<Entities.Country>
{
    public void Configure(EntityTypeBuilder<Entities.Country> builder)
    {
        builder.ToTable(nameof(Country));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnName(nameof(Entities.Country.Name))
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Code)
            .HasColumnName(nameof(Entities.Country.Code))
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(x => x.IsActive)
            .HasColumnName(nameof(Entities.Country.IsActive))
            .IsRequired();

        builder.HasMany(x => x.Cities)
                .WithOne()
                .HasForeignKey("CountryId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(x => x.Cities)
             .AutoInclude();

        builder.HasIndex(x => x.Code)
               .IsUnique();
    }
}
