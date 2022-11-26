using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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

    /// <summary>
    /// Creates an order
    /// </summary>
    /// <param name="dto">The order to be created</param>
    [HttpPost]
    [SwaggerResponse(StatusCodes.Status201Created, "Returns the created order")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Validation failure")]
    public ActionResult<Order> Create(CreateOrderDto dto)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieves all orders
    /// </summary>
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of orders")]
    public ActionResult<List<OrderListItemDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Retrieves an order by ID
    /// </summary>
    /// <param name="id">The ID of the order</param>
    [HttpGet("{id:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the order with the specified ID")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "If the order could not be found")]
    public ActionResult<Order> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Replaces the content of an existing order with the payload
    /// </summary>
    [HttpPut]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the updated order")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Validation failure")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "If there is no order with ID given in the payload")]
    public ActionResult<Order> Update(UpdateOrderDto dto)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds an item to the order
    /// </summary>
    /// <param name="id">The ID of the order</param>
    /// <param name="dto">The item to add</param>
    [HttpPost("{id:guid}/items")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the updated order")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Validation failure")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Order with specified ID could not be found")]
    public void AddItem(Guid id, CreateOrderItemDto dto)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates an item in the order
    /// </summary>
    /// <param name="id">The ID of the order</param>
    /// <param name="dto">The item to update</param>
    [HttpPut("{id:guid}/items")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the updated order")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Validation failure")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Either the order with specified ID does not exist or the specified item does not exist in the order")]
    public void UpdateItem(Guid id, CreateOrderItemDto dto)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Removes an item from the order
    /// </summary>
    /// <param name="orderId">The ID of the order</param>
    /// <param name="purchasableItemId">The ID of the purchasable item for which the order item should be removed</param>
    /// <exception cref="NotImplementedException"></exception>
    [HttpDelete("{orderId:guid}/items/{purchasableItemId:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the updated order")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Either the order with specified ID does not exist or the item with specified ID does not exist in the order")]
    public void RemoveItem(Guid orderId, Guid purchasableItemId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds a service reservation to the order
    /// </summary>
    /// <param name="orderId">The ID of the order</param>
    /// <param name="serviceReservationId">The ID of the service reservation</param>
    [HttpPost("{orderId:guid}/service-reservations/{serviceReservationId:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the updated order")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Order or service does not exist")]
    public void AddService(Guid orderId, Guid serviceReservationId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Removes a service reservation from the order
    /// </summary>
    /// <param name="orderId">The ID of the order</param>
    /// <param name="serviceReservationId">The ID of the service reservation</param>
    [HttpDelete("{orderId:guid}/service-reservations/{serviceReservationId:guid}")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns the updated order")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Either the order with specified ID does not exist or the service reservation with the specified ID does not exist in the order")]
    public void RemoveService(Guid orderId, Guid serviceReservationId)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Marks the order as completed
    /// </summary>
    /// <param name="id">The ID of the order</param>
    [HttpPost("{id:guid}/complete")]
    [SwaggerResponse(StatusCodes.Status200OK, "Success")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "It is invalid to complete an order in the current state")]
    public void Complete(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Cancels an order
    /// </summary>
    /// <param name="id">The ID of the order</param>
    [HttpPost("{id:guid}/cancel")]
    [SwaggerResponse(StatusCodes.Status200OK, "Success")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "It is invalid to cancel an order in the current state")]
    public void Cancel(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Submits a return request for the order
    /// </summary>
    /// <param name="id">The ID of the order</param>
    [HttpPost("{id:guid}/return")]
    [SwaggerResponse(StatusCodes.Status200OK, "Success")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "It is invalid to return an order in the current state")]
    public void Return(Guid id)
    {
        throw new NotImplementedException();
    }
    
    /// <summary>
    /// Refunds an order
    /// </summary>
    /// <param name="id">The ID of the order</param>
    [HttpPost("{id:guid}/refund")]
    [SwaggerResponse(StatusCodes.Status200OK, "Success")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "It is invalid to refund an order in the current state")]
    public void Refund(Guid id)
    {
        throw new NotImplementedException();
    }
}