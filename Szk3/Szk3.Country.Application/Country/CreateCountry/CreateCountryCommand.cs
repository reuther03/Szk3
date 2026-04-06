using MediatR;

namespace Szk3.Country.Application.Country.CreateCountry;

public record CreateCountryCommand(string Name, string Code, bool IsActive) : IRequest<int>;