using MediatR;
using Szk3.Country.Application.Country.Models;

namespace Szk3.Country.Application.Country.AddCity;

public record AddCityCommand(int CountryId, string Name, bool IsActive = true) : IRequest<int>;