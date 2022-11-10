using System.Globalization;
using VisualRiders.PointOfSale.Project.Enums;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project;

public class Data
{
    public static List<Branch> Branches { get; set; }
    
    public static List<Company> Companies { get; set; }
    
    public static List<Order> Orders { get; set; }

    public static List<Permission> Permissions { get; set; }
    
    public static List<Role> Roles { get; set; }

    static Data()
    {
        Companies = new()
        {
            new Company()
            {
                Id = Guid.NewGuid(),
                Name = "Company1",
                ActiveSince = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                LegalCompanyName = "Company1",
                BillingDetails = "details",
                Status = CompanyStatus.Active
            },
            new Company()
            {
                Id = Guid.NewGuid(),
                Name = "Company2",
                ActiveSince = new DateTime(2022, 11, 07).ToString(CultureInfo.InvariantCulture),
                LegalCompanyName = "Company2",
                BillingDetails = "details",
                Status = CompanyStatus.Active
            }
        };
        Branches = new()
        {
            new Branch {
                Id = Guid.NewGuid(),
                Address = "Address",
                Status = BranchStatus.Active,
                Company = Companies[0],
                Contacts = "email@domain.com",
                WorkingDays = WorkingDays.Monday | WorkingDays.Friday,
                WorkingHourEnd = new Time{ Hours = 8, Minutes = 0 },
                WorkingHourStart = new Time{ Hours = 17, Minutes = 30 },
            },
            new Branch {
                Id = Guid.NewGuid(),
                Address = "Address2",
                Status = BranchStatus.Active,
                Company = Companies[1],
                Contacts = "email2@domain.com",
                WorkingDays = WorkingDays.Monday | WorkingDays.Friday,
                WorkingHourEnd = new Time{ Hours = 8, Minutes = 0 },
                WorkingHourStart = new Time{ Hours = 17, Minutes = 0 },
            }
        };
        
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
=======
    public static List<Branch> Branches { get; set; }
    
    public static List<Company> Companies { get; set; }

    static Data()
    {
        Companies = new()
        {
            new Company()
            {
                Id = Guid.NewGuid(),
                Name = "Company1",
                ActiveSince = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                LegalCompanyName = "Company1",
                BillingDetails = "details",
                Status = CompanyStatus.Active
            },
            new Company()
            {
                Id = Guid.NewGuid(),
                Name = "Company2",
                ActiveSince = new DateTime(2022, 11, 07).ToString(CultureInfo.InvariantCulture),
                LegalCompanyName = "Company2",
                BillingDetails = "details",
                Status = CompanyStatus.Active
            }
        };
        Branches = new()
        {
            new Branch {
                Id = Guid.NewGuid(),
                Address = "Address",
                Status = BranchStatus.Active,
                Company = Companies[0],
                Contacts = "email@domain.com",
                WorkingDays = WorkingDays.Monday | WorkingDays.Friday,
                WorkingHourEnd = new Time{ Hours = 8, Minutes = 0 },
                WorkingHourStart = new Time{ Hours = 17, Minutes = 30 },
            },
            new Branch {
                Id = Guid.NewGuid(),
                Address = "Address2",
                Status = BranchStatus.Active,
                Company = Companies[1],
                Contacts = "email2@domain.com",
                WorkingDays = WorkingDays.Monday | WorkingDays.Friday,
                WorkingHourEnd = new Time{ Hours = 8, Minutes = 0 },
                WorkingHourStart = new Time{ Hours = 17, Minutes = 0 },
            }
        };
    }
}