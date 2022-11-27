namespace VisualRiders.PointOfSale.Project.Dto;

public class ApplyDiscountDto
{
    public List<Guid> PurchasableItemIds { get; set; }
    
    public List<Guid> ServiceIds { get; set; }
}