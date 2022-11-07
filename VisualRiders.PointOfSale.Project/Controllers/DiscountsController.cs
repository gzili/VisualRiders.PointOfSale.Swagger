using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountsController : Controller
    {
        private readonly DiscountsRepository _discountsRepository;

        public DiscountsController(DiscountsRepository discountsRepository)
        {
            _discountsRepository = discountsRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Discount> Create(Discount discount)
        {
            _discountsRepository.Create(discount);

            return CreatedAtAction("GetById", new { id = discount.Id }, discount);
        }

        [HttpGet]
        public List<Discount> GetAll()
        {
            return _discountsRepository.GetAll();
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Discount> GetById(Guid id)
        {
            var discount = _discountsRepository.GetById(id);

            if (discount == null)
            {
                return NotFound();
            }

            return discount;
        }

        [HttpPut("{id:guid}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Discount> UpdateById(Guid id, Discount newDiscount) {
            var discount = _discountsRepository.GetById(id);

            if (discount == null)
            {
                return NotFound();
            }
            _discountsRepository.Update(discount);
            return discount;
        }

        [HttpDelete("{id:guid}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteById(Guid id) {
            var discount = _discountsRepository.GetById(id);

            if (discount == null)
            {
                return NotFound();
            }
            _discountsRepository.Delete(discount);
            return Ok();
        }
    }
}
