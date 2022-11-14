using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Enums;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<PurchasableItem> Create(CreateUpdatePurchasableItemDto dto)
        {
            var item = _purchasableItemsRepository.Create(dto);

            return CreatedAtAction("GetById", new { id = item.Id }, item);
        }

        [HttpGet]
        public List<PurchasableItem> GetAll()
        {
            return _purchasableItemsRepository.GetAll();
        }

        [HttpGet("active")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<PurchasableItem>> GetAllActive()
        {
            var items = _purchasableItemsRepository.GetAllActive();

            if (items == null)
            {
                return NotFound();
            }

            return items;
        }

        [HttpGet("deleted")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<PurchasableItem>> GetAllDeleted()
        {
            var items = _purchasableItemsRepository.GetAllDeleted();

            if (items == null)
            {
                return NotFound();
            }

            return items;
        }

        [HttpGet("{id:guid}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PurchasableItem> GetById(Guid id)
        {
            var purchasableItem = _purchasableItemsRepository.GetById(id);

            if (purchasableItem == null)
            {
                return NotFound();
            }

            return purchasableItem;
        }

        [HttpPut("{id:guid}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PurchasableItem> UpdateById(Guid id, CreateUpdatePurchasableItemDto dto)
        {
            var purchasableItem = _purchasableItemsRepository.GetById(id);
           
            if (purchasableItem == null)
            {
                return NotFound();
            }

            _purchasableItemsRepository.Update(purchasableItem, dto);
            return purchasableItem;
        }

        [HttpPut("{id:guid}/category")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PurchasableItem> ChangeCategory(Guid id, UpdatePurchasableItemCategoryDto categoryDto)
        {
            var purchasableItem = _purchasableItemsRepository.GetById(id);

            if (purchasableItem == null)
            {
                return NotFound();
            }

            _purchasableItemsRepository.ChangeCategory(purchasableItem, categoryDto);

            return Ok();
        }

        [HttpPut("{id:guid}/status")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PurchasableItem> ChangeStatus(Guid id, UpdatePurchasableItemStatusDto dto)
        {
            var purchasableItem = _purchasableItemsRepository.GetById(id);

            if ( purchasableItem == null)
            {
                return NotFound();
            }

            _purchasableItemsRepository.ChangeStatus(purchasableItem, dto);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteById(Guid id)
        {
            var item = _purchasableItemsRepository.GetById(id);

            if( item == null || item.Status == PurchasableItemStatus.Deleted)
            {
                return NotFound();
            }

            _purchasableItemsRepository.DeleteById(item);

            return NoContent();
        }

    }
}
