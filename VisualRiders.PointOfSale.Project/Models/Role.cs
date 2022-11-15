namespace VisualRiders.PointOfSale.Project.Models;

public class Role
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public List<Permission> Permissions { get; set; }
}