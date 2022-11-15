namespace VisualRiders.PointOfSale.Project.Models;

public class OrderItem
{
    public Guid PurchasableItemId { get; set; }
    
    public int Amount { get; set; }
    
    public Guid TaxId { get; set; }
}