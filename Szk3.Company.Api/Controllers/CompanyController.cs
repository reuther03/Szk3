using MediatR;
using Microsoft.AspNetCore.Mvc;
using Szk3.Company.Application.Company.AddCompanyAddress;
using Szk3.Company.Application.Company.AddCompanyOwner;
using Szk3.Company.Application.Company.CreateCompany;
using Szk3.Company.Application.Company.GetCompanies;
using Szk3.Company.Application.Company.GetCompany;
using Szk3.Company.Application.Company.Models;

namespace Szk3.Company.Api.Controllers;

[ApiController]
[Route("api/company")]
public class CompanyController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(
        [FromBody] CreateCompanyCommand command,
        CancellationToken cancellationToken)
    {
        var companyId = await _mediator.Send(command, cancellationToken);
        return Ok(companyId);
    }

    [HttpPut("{companyId:int}/address")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddAddress(
        [FromRoute] int companyId,
        [FromBody] AddCompanyAddressCommand command,
        CancellationToken cancellationToken)
    {
        var addressId = await _mediator.Send(command with { CompanyId = companyId }, cancellationToken);
        return Ok(addressId);
    }

    [HttpPut("{companyId:int}/owner")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddOwner(
        [FromRoute] int companyId,
        [FromBody] AddCompanyOwnerCommand command,
        CancellationToken cancellationToken)
    {
        var ownerId = await _mediator.Send(command with { CompanyId = companyId }, cancellationToken);
        return Ok(ownerId);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<CompanyListDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCompaniesQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(CompanyDetailsDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCompanyQuery(id), cancellationToken);

        return Ok(result);
    }
}