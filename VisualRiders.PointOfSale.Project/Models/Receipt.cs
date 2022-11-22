namespace VisualRiders.PointOfSale.Project.Models;

public class Receipt
{
    public Guid Id { get; set; }
    
    public Guid? Customer { get; set; }
    
    public int Amount { get; set; }
    
    public decimal TotalPaid { get; set; }
    
    public Guid Tax { get; set; }
    
    public Guid? Order { get; set; }
    
}