using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemCategoriesController : ControllerBase
    {
        private readonly ItemCategoriesRepository _itemCategoriesRepository;

        public ItemCategoriesController(ItemCategoriesRepository itemCategoriesRepository)
        {
            _itemCategoriesRepository = itemCategoriesRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<ItemCategory> Create(ItemCategory itemCategory)
        {
            _itemCategoriesRepository.Create(itemCategory);

            return CreatedAtAction("GetById", new { id = itemCategory.Id }, itemCategory);
        }

        [HttpGet]
        public List<ItemCategory> GetAll()
        {
            return _itemCategoriesRepository.GetAll();
        }

        [HttpPut("{id:guid}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ItemCategory> UpdateCategory(Guid id, CreateUpdateItemCategoryDto dto)
        {
            var itemCategory = _itemCategoriesRepository.GetById(id);

            if (itemCategory == null)
            {
                return NotFound();
            }

            _itemCategoriesRepository.UpdateCategory(itemCategory, dto);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PurchasableItem> DeleteById(Guid id)
        {
            if (_itemCategoriesRepository.GetById(id) == null)
            {
                return NotFound();
            }

            _itemCategoriesRepository.DeleteById(id);

            return NoContent();
        }
    }
}
