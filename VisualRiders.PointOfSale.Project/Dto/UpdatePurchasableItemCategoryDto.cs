using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.Dto;

public class UpdatePurchasableItemCategoryDto
{
    [Required]
    public Guid CategoryId { get; set; }
}