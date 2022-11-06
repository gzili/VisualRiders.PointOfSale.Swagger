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
        [ProducesResponseType(201)]
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
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
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
        public void UpdateById(Discount discount) {
            _discountsRepository.Update(discount);
        }

        [HttpDelete("{id:guid}")]
        public void DeleteById(Discount discount) {
            _discountsRepository.Delete(discount);
        }
    }
}
