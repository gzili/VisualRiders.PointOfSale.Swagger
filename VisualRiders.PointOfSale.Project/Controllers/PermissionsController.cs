using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionsController : ControllerBase
{
    private readonly PermissionsRepository _permissionsRepository;

    public PermissionsController(PermissionsRepository permissionsRepository)
    {
        _permissionsRepository = permissionsRepository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<Permission> Create(CreateUpdatePermissionDto dto)
    {
        var permission = _permissionsRepository.Create(dto);

        return CreatedAtAction("GetById", new { id = permission.Id }, permission);
    }

    [HttpGet]
    public List<Permission> GetAll()
    {
        return _permissionsRepository.GetAll();
    }

    [HttpGet("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Permission> GetById(Guid id)
    {
        var permission = _permissionsRepository.GetById(id);

        if (permission == null)
        {
            return NotFound();
        }

        return permission;
    }

    [HttpPut("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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

    [HttpDelete("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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