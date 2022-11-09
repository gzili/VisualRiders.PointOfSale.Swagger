namespace VisualRiders.PointOfSale.Project.Dto;

public class CreateOrderItemDto
{
    public Guid PurchasableItemId { get; set; }
    
    public int Amount { get; set; }
}