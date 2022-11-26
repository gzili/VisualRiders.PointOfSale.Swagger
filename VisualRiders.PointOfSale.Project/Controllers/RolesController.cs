using Microsoft.AspNetCore.Mvc;
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<Role> Create(CreateUpdateRoleDto dto)
    {
        var role = _rolesRepository.Create(dto);

        return CreatedAtAction("GetById", new { id = role.Id }, role);
    }

    [HttpGet]
    public List<RoleListItemDto> GetAll()
    {
        return _rolesRepository.GetAll().Select(r => new RoleListItemDto
        {
            Id = r.Id,
            Title = r.Title
        }).ToList();
    }

    [HttpGet("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Role> GetById(Guid id)
    {
        var role = _rolesRepository.GetById(id);

        if (role == null)
        {
            return NotFound();
        }

        return role;
    }

    [HttpPut("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Role> Update(Guid id, CreateUpdateRoleDto dto)
    {
        var role = _rolesRepository.GetById(id);

        if (role == null)
        {
            return NotFound();
        }
        
        _rolesRepository.Update(role, dto);

        return role;
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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