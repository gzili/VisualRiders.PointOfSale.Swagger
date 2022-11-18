using VisualRiders.PointOfSale.Project.Dto;

namespace VisualRiders.PointOfSale.Project.Models;

public class OrderItem
{
    public OrderItemPurchasableItemDto PurchasableItem { get; set; }
    
    public int Amount { get; set; }
    
    public Guid TaxId { get; set; }
}