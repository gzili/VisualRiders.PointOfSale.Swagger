namespace VisualRiders.PointOfSale.Project.Dto;

public class CreateOrderDto
{
    public string Comment { get; set; }
    
    public Guid? CustomerId { get; set; }
    
    public Guid? EmployeeId { get; set; }
    
    public Guid? DiscountId { get; set; }
    
    public List<CreateOrderItemDto> Items { get; set; }
}