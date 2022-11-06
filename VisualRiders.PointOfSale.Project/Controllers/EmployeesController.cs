using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly EmployeesRepository _employeesRepository;

        public EmployeesController(EmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Employee> Create(Employee employee)
        {
            _employeesRepository.Create(employee);

            return CreatedAtAction("GetById", new { id = employee.Id }, employee);
        }

        [HttpGet]
        public List<Employee> GetAll()
        {
            return _employeesRepository.GetAll();
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Employee> GetById(Guid id)
        {
            var employee = _employeesRepository.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }


        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult UpdateById(Employee employee)
        {
            _employeesRepository.Update(employee);
            return NoContent();
        }

        [HttpPut("{id:guid}/Status")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult DisableEmployee(Employee employee)
        {
            employee.Status = EmployeeStatus.Deleted;
            _employeesRepository.Update(employee);
            return NoContent();
        }

        [HttpPut("{id:guid}/Role")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult ChangeEmployeeRole([FromRoute]Employee employee/*, [FromBody] Role role*/)
        {
            /*employee.Role = role;*/
            _employeesRepository.Update(employee);
            return NoContent();
        }

        [HttpGet("{id:guid}/Shifts")]
        public ActionResult GetAllShifts([FromRoute] Employee employee)
        {
            throw new NotImplementedException();
        }

        [HttpPost("{id:guid}/Shifts")]
        public ActionResult SetShift([FromRoute] Employee employee)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:guid}/Orders")]
        public ActionResult GetAllOrders([FromRoute] Employee employee)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult DeleteById(Employee employee)
        {
            if (!_employeesRepository.Delete(employee))
                return NotFound();
            return NoContent();
        }
    }
}
