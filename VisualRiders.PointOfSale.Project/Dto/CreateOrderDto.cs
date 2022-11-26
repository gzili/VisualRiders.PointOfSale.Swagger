using Swashbuckle.AspNetCore.Annotations;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Dto;

public class CreateOrderDto
{
    [SwaggerSchema("The `ID` of the customer the order was created by. Used for online orders.")]
    public Guid? CustomerId { get; set; }
    
    [SwaggerSchema("The `ID` of the employee the order is assigned to. Used for in-store orders.")]
    public Guid? EmployeeId { get; set; }
    
    public string Comment { get; set; }
    
    [SwaggerSchema("The amount of tips given, if already known.")]
    public decimal Tip { get; set; }
    
    public Guid? DiscountId { get; set; }
    
    public List<CreateOrderItemDto> Items { get; set; }
    
    [SwaggerSchema("Allows including services in the order by providing the `ID`s of reservations that the services were booked with.")]
    public List<Guid> ServiceReservationIds { get; set; }
}