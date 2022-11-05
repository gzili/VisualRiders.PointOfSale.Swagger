using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ServicesRepository _servicesRepository;

        public ServicesController(ServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<Service> Create(Service service)
        {
            _servicesRepository.Create(service);

            return CreatedAtAction("GetById", new { id = service.Id }, service);
        }


        public List<Service> GetAll()
        {
            return _servicesRepository.GetAll();
        }

        [HttpGet("{status:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<List<Service>> GetAllByStatus(int status)
        {
            var services = _servicesRepository.GetAllByStatus(status);

            if(services == null)
            {
                return NotFound();
            }

            return services;
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Service> GetById(Guid id)
        {
            var service = _servicesRepository.GetById(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<PurchasableItem> UpdateService(Service service)
        {

            if (service == null)
            {
                return NotFound();
            }

            _servicesRepository.UpdateItem(service);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult<PurchasableItem> DeleteById(Guid id)
        {
            if (_servicesRepository.GetById(id) == null)
            {
                return NotFound();
            }

            _servicesRepository.DeleteById(id);

            return NoContent();
        }

    }
}
