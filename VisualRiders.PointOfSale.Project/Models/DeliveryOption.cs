namespace VisualRiders.PointOfSale.Project.Models;

public class DeliveryOption
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public decimal Price { get; set; }
    
    public Guid BranchId { get; set; }
}