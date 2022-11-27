namespace VisualRiders.PointOfSale.Project.Models;

public class ItemCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid DiscountId { get; set; }
}