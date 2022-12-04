using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Enums;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("api/purchasable-items")]
[Produces("application/json")]
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

    /// <summary>
    /// Retrieves all purchasable items
    /// </summary>
    /// <remarks>
    /// Accepts optional filters as query parameters
    /// </remarks>
    /// <param name="itemCategoryId">The ID of the category to filter by</param>
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of purchasable items")]
    public List<PurchasableItem> GetAll(Guid? itemCategoryId)
    {
        return _purchasableItemsRepository.GetAll();
    }

    [HttpGet("active")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<PurchasableItem>> GetAllActive()
    {
        return _purchasableItemsRepository.GetAllActive();
    }

    [HttpGet("deleted")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<PurchasableItem>> GetAllDeleted()
    {
        return _purchasableItemsRepository.GetAllDeleted();
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
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