using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("api/companies")]
[Produces("application/json")]
public class CompaniesController : ControllerBase
{
    private readonly CompaniesRepository _companiesRepository;

    public CompaniesController(CompaniesRepository companiesRepository)
    {
        _companiesRepository = companiesRepository;
    }

    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    public ActionResult<Company> Create(CreateUpdateCompanyDto dto)
    {
        var company = _companiesRepository.Create(dto);
        return CreatedAtAction("GetById", new { id = company.Id }, company);
    }
    
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK)]
    public List<Company> GetAll()
    {
        return _companiesRepository.GetAll();
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<Company> GetById(Guid id)
    {
        var company = _companiesRepository.GetById(id);

        if (company == null)
        {
            return NotFound();
        }

        return company;
    }

    [HttpPut("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public ActionResult<Company> Update(Guid id, CreateUpdateCompanyDto dto)
    {
        var company = _companiesRepository.GetById(id);
        
        if (company == null)
        {
            return NotFound();
        }
        
        _companiesRepository.Update(company, dto);
        
        return company;
    }

    [HttpDelete("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK)]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        var company = _companiesRepository.GetById(id);
        
        if (company == null)
        {
            return NotFound();
        }

        _companiesRepository.Delete(company);

        return Ok();
    }
}