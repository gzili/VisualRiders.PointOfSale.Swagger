using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.Dto;

public class CreateUpdateRoleDto
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public List<Guid> PermissionIds { get; set; }
}