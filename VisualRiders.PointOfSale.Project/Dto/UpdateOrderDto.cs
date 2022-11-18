namespace VisualRiders.PointOfSale.Project.Dto;

public class UpdateOrderDto
{
    public decimal Tip { get; set; }
    
    public string Comment { get; set; }
    
    public object? Discount { get; set; }
    
    public object? Delivery { get; set; }
}