using VisualRiders.PointOfSale.Project.Enums;

namespace VisualRiders.PointOfSale.Project.Models;

public class PurchasableItem
{
    public Guid Id { get; set; }

    public decimal Price { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int Duration { get; set; }

    public PurchasableItemStatus Status { get; set; }

    public Guid ItemCategoryId { get; set; }

    public Guid DiscountId { get; set; }

}