using Shouldly;
using Szk3.Country.UnitTests.Builders;
using Xunit;

namespace Szk3.Country.UnitTests.Entities;

public class CountryTest
{
    [Fact]
    public void Build_Should_Create_Country_With_Default_Values()
    {
        var builder = new CountryBuilder()
            .WithDefaults(name: "Poland", code: "PL", isActive: true);

        var entity = builder.Build();

        entity.ShouldNotBeNull();
        entity.Name.ShouldBe("Poland");
        entity.Code.ShouldBe("PL");
        entity.IsActive.ShouldBeTrue();
        entity.Cities.ShouldBeEmpty();
    }

    [Fact]
    public void Build_Should_Create_Country_With_Cities()
    {
        var builder = new CountryBuilder()
            .WithName("Germany")
            .WithCode("DE")
            .WithCity("Berlin")
            .WithCity("Munich");

        var entity = builder.Build();

        entity.Name.ShouldBe("Germany");
        entity.Code.ShouldBe("DE");
        entity.Cities.Count.ShouldBe(2);
        entity.Cities.Any(x => x.Name == "Berlin").ShouldBeTrue();
        entity.Cities.Any(x => x.Name == "Munich").ShouldBeTrue();
    }

    [Fact]
    public void AddCity_Should_Add_City()
    {
        var country = new CountryBuilder()
            .WithName("Poland")
            .WithCode("PL")
            .Build();

        country.AddCity("Warsaw");

        country.Cities.Count.ShouldBe(1);
        country.Cities.Any(x => x.Name == "Warsaw").ShouldBeTrue();
        country.Cities.Single().IsActive.ShouldBeTrue();
    }

    [Fact]
    public void AddCity_Should_Add_Inactive_City_When_Requested()
    {
        var country = new CountryBuilder()
            .WithName("Poland")
            .WithCode("PL")
            .Build();

        country.AddCity("Krakow", isActive: false);

        country.Cities.Count.ShouldBe(1);
        country.Cities.Any(x => x.Name == "Krakow").ShouldBeTrue();
        country.Cities.Single().IsActive.ShouldBeFalse();
    }
}