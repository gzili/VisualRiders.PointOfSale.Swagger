using System.ComponentModel.DataAnnotations;

namespace VisualRiders.PointOfSale.Project.Dto;

public class UpdateEmployeeRoleDto
{
    [Required]
    public Guid roleId { get; set; }
}