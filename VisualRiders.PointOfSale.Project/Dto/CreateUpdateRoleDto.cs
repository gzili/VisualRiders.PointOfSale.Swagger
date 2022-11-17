namespace VisualRiders.PointOfSale.Project.Dto;

public class CreateUpdateRoleDto
{
    public string Title { get; set; }
    
    public List<Guid> PermissionIds { get; set; }
}