using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.Dto;

public class UpdateBranchContactsDto
{
    [Required]
    public string Contacts { get; set; }
}