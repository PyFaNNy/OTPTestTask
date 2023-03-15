using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestWebApi.Application.Aggregates.Employee.Commands.CreateEmployee;
using TestWebApi.Application.Aggregates.Employee.Commands.DeleteEmployee;
using TestWebApi.Application.Aggregates.Employee.Commands.UpdateEmployee;
using TestWebApi.Application.Aggregates.Employee.Queries.GetEmployee;
using TestWebApi.Application.Aggregates.Employee.Queries.GetEmployees;
using TestWebApi.Application.Models;

namespace TestWebApi.Controllers;

/// <summary>
/// Controller manage empluyeies
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class EmployeeController : BaseController 
{
    /// <summary>
    /// Constructor
    /// </summary>
    public EmployeeController() : base()
    {
    }
    
    /// <summary>
    /// Get paginatedList of employee
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<PaginatedList<Application.Aggregates.Employee.Queries.GetEmployees.Employee>>> GetModels(int? pageIndex = 1,
        int? pageSize = 10)
    {
        var result = await Mediator.Send(new GetEmployeesQuery(pageIndex, pageSize));
        return Ok(result);
    }

    /// <summary>
    /// Get specific employee by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetModel(int id)
    {
        var result = await Mediator.Send(new GetEmployeeQuery { EmployeeId = id });
        return Ok(result);
    }

    /// <summary>
    /// Create employee
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddModel(CreateEmployeeCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    /// <summary>
    /// Update employee
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateModel(UpdateEmployeeCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    /// <summary>
    /// Delete specific employee
    /// </summary>
    /// <param name="employeeId"></param>
    /// <returns></returns>
    [HttpDelete]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteModel(int employeeId)
    {
        await Mediator.Send(new DeleteEmployeeCommand {EmployeeId = employeeId});
        return NoContent();
    }
}