using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using VisualRiders.PointOfSale.Project.Dto;
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


        [HttpGet("{status:int}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<PurchasableItem>> GetAllByStatus(int status)
        {
            var items = _purchasableItemsRepository.GetAllByStatus(status);

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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PurchasableItem> DeleteById(Guid id)
        {
            var item = _purchasableItemsRepository.GetById(id);

            if( item == null || item.Status == Enums.PurchasableItemStatus.Deleted)
            {
                return NotFound();
            }

            _purchasableItemsRepository.DeleteById(id);

            return NoContent();
        }

    }
}
