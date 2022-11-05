using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchasableItemsController : ControllerBase
    {
        private readonly PurchasableItemsRepository _purchasableItemsRepository;

        public PurchasableItemsController(PurchasableItemsRepository purchasableItemsRepository)
        {
            _purchasableItemsRepository = purchasableItemsRepository;
        }


        [HttpPost]
        [ProducesResponseType(201)]
        public ActionResult<PurchasableItem> Create(PurchasableItem purchasableItem)
        {
            _purchasableItemsRepository.Create(purchasableItem);

            return CreatedAtAction("GetById", new { id = purchasableItem.Id }, purchasableItem);
        }


        [HttpGet]
        public List<PurchasableItem> GetAll()
        {
            return _purchasableItemsRepository.GetAll();
        }


        [HttpGet("{status:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<List<PurchasableItem>> GetAllByStatus(int status)
        {
            var items = _purchasableItemsRepository.GetAllByStatus(status);

            if (items == null)
            {
                return NotFound();
            }

            return _purchasableItemsRepository.GetAllByStatus(status);
        }


        [HttpGet("{id:guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<PurchasableItem> GetById(Guid id)
        {
            var purchasableItem = _purchasableItemsRepository.GetById(id);

            if(purchasableItem == null)
            {
                return NotFound();
            }

            return purchasableItem;
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<PurchasableItem> UpdateItem(PurchasableItem purchasableItem)
        {
           
            if (purchasableItem == null)
            {
                return NotFound();
            }

            _purchasableItemsRepository.UpdateItem(purchasableItem);
            return Ok();
        }


        [HttpPut("{id:guid}/category")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult<PurchasableItem> AddCategory(Guid id, UpdateProductCategoryDto categoryDto)
        {
            if(_purchasableItemsRepository.GetById(id) == null)
            {
                return NotFound();
            }

            if(categoryDto == null)
            {
                return BadRequest();
            }

            _purchasableItemsRepository.AddCathegory(id, categoryDto.CategoryId);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult<PurchasableItem> DeleteById(Guid id)
        {
            if(_purchasableItemsRepository.GetById(id) == null)
            {
                return NotFound();
            }

            _purchasableItemsRepository.DeleteById(id);

            return NoContent();
        }

    }
}
