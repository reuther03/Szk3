using MediatR;

namespace Szk3.Country.Application.Country.CreateCountry;

public sealed record CreateCountryCommand(
 string Name,
 string Code,
 bool IsActive = true) : IRequest<int>;
