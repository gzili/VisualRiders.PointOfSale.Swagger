using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("api/roles")]
public class RolesController : ControllerBase
{
    private readonly RolesRepository _rolesRepository;

    public RolesController(RolesRepository rolesRepository)
    {
        _rolesRepository = rolesRepository;
    }

    /// <summary>
    /// Creates a named role with specified permissions
    /// </summary>
    /// <param name="payload">The role to create</param>
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, "Returns the created role")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid payload")]
    public ActionResult<Role> Create(CreateUpdateRoleDto payload)
    {
        var role = _rolesRepository.Create(payload);

        return CreatedAtAction("GetById", new { id = role.Id }, role);
    }

    /// <summary>
    /// Retrieves all roles
    /// </summary>
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of roles")]
    public List<RoleListItemDto> GetAll()
    {
        return _rolesRepository.GetAll().Select(r => new RoleListItemDto
        {
            Id = r.Id,
            Title = r.Title
        }).ToList();
    }

    /// <summary>
    /// Retrieves a role by ID
    /// </summary>
    /// <param name="id">The ID of the role to retrieve</param>
    [HttpGet("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the requested role")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The role with the specified ID does not exist")]
    public ActionResult<Role> GetById(Guid id)
    {
        var role = _rolesRepository.GetById(id);

        if (role == null)
        {
            return NotFound();
        }

        return role;
    }

    /// <summary>
    /// Updates a role
    /// </summary>
    /// <param name="id">The ID of the role to update</param>
    /// <param name="payload">The role payload</param>
    [HttpPut("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the updated role")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The role with the specified ID does not exist")]
    public ActionResult<Role> Update(Guid id, CreateUpdateRoleDto payload)
    {
        var role = _rolesRepository.GetById(id);

        if (role == null)
        {
            return NotFound();
        }
        
        _rolesRepository.Update(role, payload);

        return role;
    }
    
    /// <summary>
    /// Deletes a role
    /// </summary>
    /// <param name="id">The ID of the role to delete</param>
    [HttpDelete("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the requested role")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The role with the specified ID does not exist")]
    public IActionResult Delete(Guid id)
    {
        var role = _rolesRepository.GetById(id);

        if (role == null)
        {
            return NotFound();
        }
        
        _rolesRepository.Delete(role);

        return Ok();
    }
}