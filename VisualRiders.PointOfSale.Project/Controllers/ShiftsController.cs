using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("api/shifts")]
[Produces("application/json")]
public class ShiftsController : ControllerBase
{
    /// <summary>
    /// Creates a shift
    /// </summary>
    /// <param name="payload">The shift to create</param>
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, "Returns the created shift")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The payload is invalid")]
    public ActionResult<Shift> Create(CreateUpdateShiftDto payload)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieves all shifts, filtered by specified parameters
    /// </summary>
    /// <param name="branchId">The ID of the branch to show shifts from</param>
    /// <param name="employeeId">The ID of the employee the shifts are assigned to</param>
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of shifts")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid parameters")]
    public List<Shift> GetAll(Guid? branchId, Guid? employeeId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieves a shift by ID
    /// </summary>
    /// <param name="id">The ID of the shift to retrieve</param>
    [HttpGet("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a shift")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The shift with specified ID does not exist")]
    public ActionResult<Shift> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates an existing shift
    /// </summary>
    /// <param name="id">The ID of the shift to update</param>
    /// <param name="payload">The payload to replace the specified shift with</param>
    [HttpPut("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the updated shift")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid payload")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The shift with the specified ID does not exist")]
    public ActionResult<Shift> Update(Guid id, CreateUpdateShiftDto payload)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a shift
    /// </summary>
    /// <param name="id">The ID of the shift to delete</param>
    [HttpDelete("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Returns on successful deletion")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The shift with the specified ID does not exist")]
    public ActionResult<Shift> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}