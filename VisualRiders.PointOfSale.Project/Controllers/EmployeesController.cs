using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeesController : Controller
{
    private readonly EmployeesRepository _employeesRepository;

    public EmployeesController(EmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    /// <summary>
    /// Creates a new employee account
    /// </summary>
    /// <param name="payload">The details of the new employee account</param>
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, "Returns the created employee")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid payload")]
    public ActionResult<EmployeeDto> Create(CreateEmployeeDto payload)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public List<EmployeeListItemDto> GetAll()
    {
        return _employeesRepository.GetAll().Select(e => new EmployeeListItemDto
        { 
            Id = e.Id, 
            Name = e.Name
        }).ToList();
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<EmployeeDto> GetById(Guid id)
    {
        var employee = _employeesRepository.GetById(id);

        if (employee == null)
        {
            return NotFound();
        }

        return new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.Name,
            CompanyId = employee.CompanyId,
            Email = employee.Email,
            RoleId = employee.RoleId,
            Status = employee.Status
        };
    }


    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<EmployeeDto> UpdateById(Guid id, Employee newEmployee)
    {
        var employee = _employeesRepository.GetById(id);

        if (employee == null)
        {
            return NotFound();
        }
        newEmployee.Id = id;
        _employeesRepository.Update(employee);
        return new EmployeeDto
        {
            Id = employee.Id,
            CompanyId = employee.CompanyId,
            Email = employee.Email,
            Name = employee.Name,
            RoleId = employee.RoleId,
            Status = employee.Status
        };
    }

    [HttpPut("{id:guid}/role")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult ChangeEmployeeRole(Guid id, UpdateEmployeeRoleDto roleDto)
    {
        var employee = _employeesRepository.GetById(id);

        if (employee == null)
        {
            return NotFound();
        }

        _employeesRepository.ChangeRole(employee, roleDto);

        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteById(Guid id)
    {
        if (!_employeesRepository.Delete(id))
        {
            return NotFound();
        }

        return NoContent();
    }
}