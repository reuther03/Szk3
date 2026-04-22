using Shouldly;
using Szk3.Company.Domain.Entities.JobPosition;
using Szk3.Company.Domain.Enums;
using Szk3.Company.Tests.Builders;
using Xunit;

namespace Szk3.Company.Tests.Tests;

public class JobPositionTest
{
    [Fact]
    public void Build_Should_Create_JobPosition_With_Default_Values()
    {
        // Arrange
        var builder = new JobPositionBuilder()
            .WithDefaults(name: "Software Developer", code: "DEV-01", isActive: true);

        // Act
        var entity = builder.Build();

        // Assert
        entity.ShouldNotBeNull();
        entity.Name.ShouldBe("Software Developer");
        entity.Code.ShouldBe("DEV-01");
        entity.IsActive.ShouldBeTrue();
        entity.Rates.ShouldBeEmpty();
        entity.Requirement.ShouldBeEmpty();
    }

    [Fact]
    public void AddRate_Should_Add_Rate_To_Collection()
    {
        // Arrange
        var jobPosition = new JobPositionBuilder()
            .WithName("Software Developer")
            .WithCode("DEV-01")
            .Build();

        var rate = new PositionRate(10, "PLN", RateType.Hourly);

        // Act
        jobPosition.AddRate(rate);

        // Assert
        jobPosition.Rates.Count.ShouldBe(1);
        jobPosition.Rates.ShouldContain(rate);
    }

    [Fact]
    public void AddRate_Should_Throw_InvalidOperationException_When_Rate_Already_Exists()
    {
        // Arrange
        var jobPosition = new JobPositionBuilder()
            .WithName("Software Developer")
            .Build();

        var rate = new PositionRate(10, "PLN", RateType.Hourly);
        jobPosition.AddRate(rate);

        // Act & Assert
        var exception = Should.Throw<InvalidOperationException>(() => jobPosition.AddRate(rate));
        exception.Message.ShouldBe("Rate already exists for this position.");
    }

    [Fact]
    public void AddRequirement_Should_Add_Requirement_To_Collection()
    {
        // Arrange
        var jobPosition = new JobPositionBuilder()
            .WithName("Software Developer")
            .Build();

        var requirement = new PositionRequirement("Must have experience with C# and .NET", null);

        // Act
        jobPosition.AddRequirement(requirement);

        // Assert
        jobPosition.Requirement.Count.ShouldBe(1);
        jobPosition.Requirement.ShouldContain(requirement);
    }

    [Fact]
    public void AddRequirement_Should_Throw_InvalidOperationException_When_Requirement_Already_Exists()
    {
        // Arrange
        var jobPosition = new JobPositionBuilder()
            .WithName("Software Developer")
            .Build();

        var requirement = new PositionRequirement("Must have experience with C# and .NET", null);
        jobPosition.AddRequirement(requirement);

        // Act & Assert
        var exception =
            Should.Throw<InvalidOperationException>(() => jobPosition.AddRequirement(requirement));
        exception.Message.ShouldBe("Requirement already exists for this position.");
    }

    [Fact]
    public void Activate_Should_Set_IsActive_To_True()
    {
        // Arrange
        var jobPosition = new JobPositionBuilder()
            .WithIsActive(false)
            .Build();

        // Act
        jobPosition.Activate();

        // Assert
        jobPosition.IsActive.ShouldBeTrue();
    }

    [Fact]
    public void Deactivate_Should_Set_IsActive_To_False()
    {
        // Arrange
        var jobPosition = new JobPositionBuilder()
            .WithIsActive(true)
            .Build();

        // Act
        jobPosition.Deactivate();

        // Assert
        jobPosition.IsActive.ShouldBeFalse();
    }
}