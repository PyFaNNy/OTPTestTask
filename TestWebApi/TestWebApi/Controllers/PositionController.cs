using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestWebApi.Application.Aggregates.Position.Commands.CreatePosition;
using TestWebApi.Application.Aggregates.Position.Commands.DeletePosition;
using TestWebApi.Application.Aggregates.Position.Commands.UpdatePosition;
using TestWebApi.Application.Aggregates.Position.Queries.GetPosition;
using TestWebApi.Application.Aggregates.Position.Queries.GetPositions;
using TestWebApi.Application.Models;

namespace TestWebApi.Controllers;

/// <summary>
/// Controller manage positions
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PositionController : BaseController
{
    /// <summary>
    /// Constructor
    /// </summary>
    public PositionController() : base()
    {
    }

    /// <summary>
    /// Get paginatedList of positions
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetModels(int? pageIndex = 1,
        int? pageSize = 10)
    {
        var result = await Mediator.Send(new GetPositionsQuery(pageIndex, pageSize));
        return Ok(result);
    }
    
    /// <summary>
    /// Get specific position by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetModel(int id)
    {
        var result = await Mediator.Send(new GetPositionQuery {PositionId = id});
        return Ok(result);
    }
    
    /// <summary>
    /// Create position
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddModel(CreatePositionCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    /// <summary>
    /// Update position
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateModel(UpdatePositionCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    /// <summary>
    /// Delete position
    /// </summary>
    /// <param name="positionId"></param>
    /// <returns></returns>
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteModel(int positionId)
    {
        await Mediator.Send(new DeletePositionCommand {PositionId = positionId});
        return NoContent();
    }
}