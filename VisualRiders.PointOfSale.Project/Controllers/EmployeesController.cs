using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : Controller
    {
        private readonly EmployeesRepository _employeesRepository;

        public EmployeesController(EmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<EmployeeDto> Create(Employee employee)
        {
            _employeesRepository.Create(employee);

            return CreatedAtAction("GetById", new { id = employee.Id }, new EmployeeDto
            {
                Id = employee.Id,
                CompanyId = employee.CompanyId,
                Email = employee.Email,
                Name = employee.Name,
                RoleId = employee.RoleId,
                Status = employee.Status
            });
        }

        [HttpGet]
        public List<EmployeeListItemDto> GetAll()
        {
            return _employeesRepository.GetAll().Select(e => new EmployeeListItemDto() { 
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

            return new EmployeeDto()
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
        public ActionResult<EmployeeDto> UpdateById([FromRoute] Guid id, Employee newEmployee)
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

        [HttpPut("{id:guid}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EmployeeDto> DisableEmployee([FromRoute] Guid id, EmployeeDto newEmployee)
        {
            var employee = _employeesRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }
            employee.Status = newEmployee.Status;
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
        public ActionResult ChangeEmployeeRole([FromRoute]Guid id, UpdateEmployeeRoleDto roleDto)
        {
            var employee = _employeesRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            if (roleDto == null)
            {
                return BadRequest();
            }

            _employeesRepository.ChangeRole(employee, roleDto);

            return Ok();
        }

        [HttpGet("{id:guid}/shifts")]
        public ActionResult GetAllShifts([FromRoute] Employee employee)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{id:guid}/shifts")]
        public ActionResult SetShift([FromRoute] Employee employee)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:guid}/orders")]
        public ActionResult GetAllOrders([FromRoute] Employee employee)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteById([FromRoute] Guid id)
        {
            if (!_employeesRepository.Delete(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
