using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly OrdersRepository _ordersRepository;

    public OrdersController(OrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    [HttpPost]
    public ActionResult<Order> Create(CreateOrderDto dto)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public ActionResult<List<OrderListItemDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id:guid}")]
    public ActionResult<Order> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public ActionResult<Order> Update()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds an item to the order
    /// </summary>
    [HttpPost("{orderId:guid}/items")]
    public void AddOrderItem(Guid orderId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates an item in the order
    /// </summary>
    [HttpPut("{orderId:guid}/items")]
    public void UpdateOrderItem(Guid orderId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes an item from the order
    /// </summary>
    [HttpDelete("{orderId:guid}/items/{itemId:guid}")]
    public void RemoveOrderItem(Guid orderId, Guid itemId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Marks the order as completed
    /// </summary>
    /// <response code="200">Success</response>
    /// <response code="400">The order is in a state that does not allow completion.</response>
    [HttpPost("complete")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void Complete()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Cancels an order
    /// </summary>
    /// <response code="200">Success</response>
    /// <response code="400">The order is in a state that does not allow cancellation.</response>
    [HttpPost("cancel")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void Cancel()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Marks the order as completed
    /// </summary>
    /// <response code="200">Success</response>
    /// <response code="400">The order is in a state that does not allow return.</response>
    [HttpPost("return")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void Return()
    {
        throw new NotImplementedException();
    }
}