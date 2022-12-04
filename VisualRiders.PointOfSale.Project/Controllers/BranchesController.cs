using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("api/branches")]
[Produces("application/json")]
public class BranchesController : ControllerBase
{
    private readonly BranchesRepository _branchesRepository;

    public BranchesController(BranchesRepository branchesRepository)
    {
        _branchesRepository = branchesRepository;
    }

    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    public ActionResult<Branch> Create(CreateUpdateBranchDto payload)
    {
        var branch = _branchesRepository.Create(payload);
        return CreatedAtAction("GetById", new { id = branch.Id }, branch);
    }

    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK)]
    public List<Branch> GetAll()
    {
        return _branchesRepository.GetAll();
    }
    
    [HttpGet("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<Branch> GetById(Guid id)
    {
        var branch = _branchesRepository.GetById(id);

        if (branch == null)
        {
            return NotFound();
        }

        return branch;
    }

    [HttpPut("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<Branch> Update(Guid id, CreateUpdateBranchDto payload)
    {
        var branch = _branchesRepository.GetById(id);
        
        if (branch == null)
        {
            return NotFound();
        }
        
        _branchesRepository.Update(branch, payload);
        
        return branch;
    }
    
    [HttpPut("{id:guid}/working-hours")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<Branch> UpdateWorkingHours(Guid id, UpdateBranchWorkingHoursDto payload)
    {
        var branch = _branchesRepository.GetById(id);

        if (branch == null)
        {
            return NotFound();
        }

        _branchesRepository.UpdateWorkingHours(branch, payload);

        return branch;
    }

    [HttpPut("{id:guid}/contacts")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<Branch> UpdateContacts(Guid id, UpdateBranchContactsDto payload)
    {
        var branch = _branchesRepository.GetById(id);

        if (branch == null)
        {
            return NotFound();
        }

        _branchesRepository.UpdateContacts(branch, payload);

        return branch;
    }

    [HttpDelete("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        var branch = _branchesRepository.GetById(id);
        
        if (branch == null)
        {
            return NotFound();
        }

        _branchesRepository.Delete(branch);

        return Ok();
    }
}