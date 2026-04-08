using MediatR;
using Microsoft.AspNetCore.Mvc;
using Szk3.Company.Application.JobPosition.AddPositionRate;
using Szk3.Company.Application.JobPosition.AddPositionRequirement;
using Szk3.Company.Application.JobPosition.CreateJobPosition;
using Szk3.Company.Application.JobPosition.DeleteJobPosition;
using Szk3.Company.Application.JobPosition.GetJobPosition;
using Szk3.Company.Application.JobPosition.GetJobPositions;
using Szk3.Company.Application.JobPosition.Models;

namespace Szk3.Company.Api.Controllers;

[ApiController]
[Route("api/job-position")]
public class JobPositionController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobPositionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(
        [FromBody] CreateJobPositionCommand command,
        CancellationToken cancellationToken)
    {
        var jobPositionId = await _mediator.Send(command, cancellationToken);
        return Ok(jobPositionId);
    }

    [HttpPost("{jobPositionId:int}/rate")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddRate(
        [FromRoute] int jobPositionId,
        [FromBody] AddPositionRateCommand command,
        CancellationToken cancellationToken)
    {
        var rateId = await _mediator.Send(command with { JobPositionId = jobPositionId }, cancellationToken);
        return Ok(rateId);
    }

    [HttpPost("{jobPositionId:int}/requirement")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddRequirement(
        [FromRoute] int jobPositionId,
        [FromBody] AddPositionRequirementCommand command,
        CancellationToken cancellationToken)
    {
        var requirementId = await _mediator.Send(command with { JobPositionId = jobPositionId }, cancellationToken);
        return Ok(requirementId);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<JobPositionDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetJobPositionsQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(JobPositionDetailsDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetJobPositionQuery(id), cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        [FromRoute] int id,
        CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteJobPositionCommand(id), cancellationToken);
        return NoContent();
    }
}