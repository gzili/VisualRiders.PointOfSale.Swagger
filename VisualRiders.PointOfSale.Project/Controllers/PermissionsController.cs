using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("api/permissions")]
[Produces("application/json")]
public class PermissionsController : ControllerBase
{
    private readonly PermissionsRepository _permissionsRepository;

    public PermissionsController(PermissionsRepository permissionsRepository)
    {
        _permissionsRepository = permissionsRepository;
    }

    /// <summary>
    /// Creates a permission
    /// </summary>
    /// <param name="dto"></param>
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, "Returns the created permission")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Validation failure")]
    public ActionResult<Permission> Create(CreateUpdatePermissionDto dto)
    {
        var permission = _permissionsRepository.Create(dto);

        return CreatedAtAction("GetById", new { id = permission.Id }, permission);
    }

    /// <summary>
    /// Retrieves all permissions
    /// </summary>
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of permissions")]
    public List<Permission> GetAll()
    {
        return _permissionsRepository.GetAll();
    }

    /// <summary>
    /// Retrieves a permission by ID
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a permission")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Permission with the specified ID does not exist")]
    public ActionResult<Permission> GetById(Guid id)
    {
        var permission = _permissionsRepository.GetById(id);

        if (permission == null)
        {
            return NotFound();
        }

        return permission;
    }

    /// <summary>
    /// Updates a permission
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    [HttpPut("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the updated permission")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Permission with the specified ID does not exist")]
    public ActionResult<Permission> Update(Guid id, CreateUpdatePermissionDto dto)
    {
        var permission = _permissionsRepository.GetById(id);

        if (permission == null)
        {
            return NotFound();
        }
        
        _permissionsRepository.Update(permission, dto);

        return permission;
    }

    /// <summary>
    /// Deletes a permission
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Permission was successfully deleted")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Permission with the specified ID does not exist")]
    public IActionResult Delete(Guid id)
    {
        var permission = _permissionsRepository.GetById(id);

        if (permission == null)
        {
            return NotFound();
        }
        
        _permissionsRepository.Remove(permission);

        return Ok();
    }
}