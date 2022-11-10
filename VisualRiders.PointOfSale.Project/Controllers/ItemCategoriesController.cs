using Microsoft.AspNetCore.Mvc;
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
        [ProducesResponseType(201)]
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


        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<PurchasableItem> UpdateCategory(ItemCategory itemCategory)
        {

            if (itemCategory == null)
            {
                return NotFound();
            }

            _itemCategoriesRepository.UpdateCategory(itemCategory);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
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
