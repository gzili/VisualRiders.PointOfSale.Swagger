using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace VisualRiders.PointOfSale.Project.Dto;

public class ApplyItemCategoryDto
{
    [Required]
    [SwaggerSchema(Description = "The IDs of purchasable items to apply this category to")]
    public List<Guid> PurchasableItemIds { get; set; }
}