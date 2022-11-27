using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.Dto;

public class ApplyDiscountCodeDto
{
    [Required]
    public string Code { get; set; }
}