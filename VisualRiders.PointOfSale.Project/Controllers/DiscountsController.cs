using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("api/discounts")]
[Produces("application/json")]
public class DiscountsController : Controller
{
    private readonly DiscountsRepository _discountsRepository;

    public DiscountsController(DiscountsRepository discountsRepository)
    {
        _discountsRepository = discountsRepository;
    }

    /// <summary>
    /// Creates a discount
    /// </summary>
    /// <param name="discount">The discount to create</param>
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, "Returns the created discount")]
    public ActionResult<Discount> Create(Discount discount)
    {
        _discountsRepository.Create(discount);

        return CreatedAtAction("GetById", new { id = discount.Id }, discount);
    }

    /// <summary>
    /// Retrieves all discounts
    /// </summary>
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of discounts")]
    public List<Discount> GetAll()
    {
        return _discountsRepository.GetAll();
    }

    [HttpGet("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the requested discount")]
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

    /// <summary>
    /// Applies a discount to the specified purchasable items and services
    /// </summary>
    /// <param name="id">The ID of the discount to apply</param>
    /// <param name="payload">Payload containing the IDs of purchasable items and services to apply the discount to</param>
    [HttpPost("{id:guid}/apply")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the count of affected items (includes items that already have the discount applied)")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid payload or incorrect item IDs")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The requested discount could not be found")]
    public ActionResult<ApplyDiscountResponseDto> ApplyTo(Guid id, ApplyDiscountDto payload)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Removes a discount from the specified purchasable items and services
    /// </summary>
    /// <param name="id">The ID of the discount to remove</param>
    /// <param name="payload">Payload containing the IDs of purchasable items and services to remove the discount from</param>
    [HttpDelete("{id:guid}/apply")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the count of affected items")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid payload or incorrect item IDs")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The requested discount could not be found")]
    public ActionResult<ApplyDiscountResponseDto> RemoveFrom(Guid id, ApplyDiscountDto payload)
    {
        throw new NotImplementedException();
    }
}