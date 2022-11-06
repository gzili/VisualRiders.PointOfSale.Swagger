using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using VisualRiders.PointOfSale.Project.Dto;
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
        public ActionResult<Service> Create(CreateUpdateServiceDto dto)
        {
            var service = _servicesRepository.Create(dto);

            return CreatedAtAction("GetById", new { id = service.Id }, service);
        }

        [HttpGet]
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

        [HttpPut("{id:guid}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PurchasableItem> UpdateById(Guid id, CreateUpdateServiceDto dto)
        {
            var service = _servicesRepository.GetById(id);

            if (service == null)
            {
                return NotFound();
            }

            _servicesRepository.Update(service, dto);

            return Ok();
        }

        //public void ChangeDiscount() { }
        //public void ChangeBranch() { }

        [HttpPut("{id:guid}/status")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PurchasableItem> ChangeStatus(Guid id, UpdateServiceStatusDto dto)
        {
            var service = _servicesRepository.GetById(id);

            if (service == null)
            {
                return NotFound();
            }

            if (dto == null)
            {
                return BadRequest();
            }

            _servicesRepository.ChangeStatus(service, dto);

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
