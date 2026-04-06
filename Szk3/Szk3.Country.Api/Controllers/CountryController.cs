using MediatR;
using Microsoft.AspNetCore.Mvc;
using Szk3.Country.Application.Country.AddCity;
using Szk3.Country.Application.Country.CreateCountry;
using Szk3.Country.Application.Country.GetCountry;
using Szk3.Country.Application.Country.Models;

namespace Szk3.Country.Api.Controllers;

[ApiController]
[Route("api/country")]
public class CountryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CountryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] CreateCountryCommand command, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("{countryId:int}/city")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<ActionResult<int>> CreateCity([FromRoute] int countryId, [FromBody] AddCityCommand request, CancellationToken cancellationToken = default)
    {
        var cityId = await _mediator.Send(request, cancellationToken);
        return Ok(cityId);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(CountryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CountryDto>> GetById([FromRoute] int id, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(new GetCountryQuery(id), cancellationToken);
        return Ok(result);
    }
}