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
        [ProducesResponseType(StatusCodes.Status201Created)]
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
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PurchasableItem> DeleteById(Guid id)
        {

            var service = _servicesRepository.GetById(id);

            if (service == null || service.Status == Enums.ServiceStatus.Deleted)
            {
                return NotFound();
            }

            _servicesRepository.DeleteById(id);

            return NoContent();
        }

    }
}
