using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project;

public class Data
{
    public static List<Order> Orders { get; set; }

    public static List<Permission> Permissions { get; set; }
    
    public static List<Role> Roles { get; set; }

    static Data()
    {
        Orders = new List<Order>();
        
        var permission1 = new Permission
        {
            Id = Guid.NewGuid(),
            Title = "Create products"
        };
        
        var permission2 = new Permission
        {
            Id = Guid.NewGuid(),
            Title = "Create products"
        };
        
        var permission3 = new Permission
        {
            Id = Guid.NewGuid(),
            Title = "Create products"
        };
        
        var permission4 = new Permission
        {
            Id = Guid.NewGuid(),
            Title = "Create products"
        };

        Permissions = new List<Permission>
        {
            permission1,
            permission2,
            permission3,
            permission4
        };

        var role1 = new Role
        {
            Id = Guid.NewGuid(),
            Title = "Inventory Manager",
            Permissions = new List<Permission>()
        };
        
        role1.Permissions.AddRange(Permissions);

        Roles = new List<Role>
        {
            role1
        };
    }
}