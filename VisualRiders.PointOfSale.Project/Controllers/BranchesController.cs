using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BranchesController : ControllerBase
{
    private readonly BranchesRepository _branchesRepository;

    public BranchesController(BranchesRepository branchesRepository)
    {
        _branchesRepository = branchesRepository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<Branch> Create(CreateUpdateBranchDto dto)
    {
        var branch = _branchesRepository.Create(dto);
        return CreatedAtAction("GetById", new { id = branch.Id }, branch);
    }

    [HttpGet("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Branch> GetById(Guid id)
    {
        var branch = _branchesRepository.GetById(id);

        if (branch == null)
        {
            return NotFound();
        }

        return branch;
    }

    [HttpGet]
    public List<Branch> GetAll()
    {
        return _branchesRepository.GetAll();
    }

    [HttpPut("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Branch> Update(Guid id, CreateUpdateBranchDto dto)
    {
        var branch = _branchesRepository.GetById(id);
        
        if (branch == null)
        {
            return NotFound();
        }
        
        _branchesRepository.Update(branch, dto);
        
        return branch;
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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