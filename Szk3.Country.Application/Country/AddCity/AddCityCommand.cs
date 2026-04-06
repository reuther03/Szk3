using MediatR;

namespace Szk3.Country.Application.Country.AddCity;

public sealed record AddCityCommand(
    int CountryId,
    string Name,
    bool IsActive = true) : IRequest<int>;