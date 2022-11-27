using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.Dto;

public class CreateUpdateItemCategoryDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }
}