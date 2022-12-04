using Swashbuckle.AspNetCore.Annotations;
using VisualRiders.PointOfSale.Project.Enums;

namespace VisualRiders.PointOfSale.Project.Models;

[SwaggerSchema(Description = "An item that can be purchased directly by a customer")]
public class PurchasableItem
{
    public Guid Id { get; set; }

    public decimal Price { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
    
    public PurchasableItemStatus Status { get; set; }

    public Guid ItemCategoryId { get; set; }

    public Guid DiscountId { get; set; }

}