namespace VisualRiders.PointOfSale.Project.Dto;

public class UpdateOrderDto
{
    public decimal Tip { get; set; }
    
    public string Comment { get; set; }
    
    public Guid? DiscountId { get; set; }
    
    public List<CreateOrderItemDto> Items { get; set; }
    
    public List<Guid> ServiceReservationIds { get; set; }
}