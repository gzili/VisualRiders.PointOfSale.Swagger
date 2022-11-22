using System.Globalization;
using VisualRiders.PointOfSale.Project.Enums;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project;

public class Data
{
    public static List<Branch> Branches { get; set; }
    
    public static List<Company> Companies { get; set; }
    
    public static List<Order> Orders { get; set; }

    public static List<Permission> Permissions { get; set; }
    
    public static List<Role> Roles { get; set; }
    
    public static List<Reservation> Reservations { get; set; }
    
    private static List<Employee> Employees { get; set; }
    
    private static List<Service> Services { get; set; }
    
    public static List<Receipt> Receipts { get; set; }
    
    static Data()
    {
        Companies = new()
        {
            new Company
            {
                Id = Guid.NewGuid(),
                Name = "Company1",
                ActiveSince = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                LegalCompanyName = "Company1",
                BillingDetails = "details",
                Status = CompanyStatus.Active
            },
            new Company
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
        
        Employees = new()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Email = "user1@mail.com",
                Name = "Antanas",
                Password = "Antanas123",
                Status = EmployeeStatus.Active
            },
            new()
            {
                Id = Guid.NewGuid(),
                Email = "user2@mail.com",
                Name = "Petras",
                Password = "Petras123",
                Status = EmployeeStatus.Active
            }
        };
    
        Services = new List<Service>(){
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Service 1",
                Description = "Description 1",
                Price = 1.0M,
                Type = ServiceType.Type2,
                Status = ServiceStatus.Deleted,
                DiscountId = Guid.NewGuid(),
                BranchId = Guid.NewGuid()
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Service 2",
                Description = "Description 2",
                Price = 2.0M,
                Type = ServiceType.Type2,
                Status = ServiceStatus.Active,
                DiscountId = Guid.NewGuid(),
                BranchId = Guid.NewGuid()
            }
        };


        Reservations = new()
        {
            new Reservation()
            {
                Id = Guid.NewGuid(),
                Employee = Employees[0],
                StartTime = new DateTime(2022, 10, 20, 8, 0, 0),
                EndTime = new DateTime(2022, 10, 20, 8, 30, 0),
                Order = Guid.NewGuid(),
                ReservationStatus = ReservationStatus.Registered,
                Service = Services[0],
                Tax = Guid.NewGuid()
            },
            new Reservation()
            {
            Id = Guid.NewGuid(),
            Employee = Employees[1],
            StartTime = new DateTime(2022, 10, 20, 9, 0, 0),
            EndTime = new DateTime(2022, 10, 20, 9, 30, 0),
            Order = Guid.NewGuid(),
            ReservationStatus = ReservationStatus.Submitted,
            Service = Services[1],
            Tax = Guid.NewGuid()
        }
        };
        
        Orders = new List<Order>();

        var customerId = Guid.NewGuid();

        Receipts = new List<Receipt>()
        {
            new Receipt()
            {
                Amount = 2,
                Customer = customerId,
                Id = Guid.NewGuid(),
                Order = Guid.NewGuid(),
                TotalPaid = 19,
                Tax = Guid.NewGuid(),

            },
            
            new Receipt()
            {
                Amount = 1,
                Customer = customerId,
                Id = Guid.NewGuid(),
                Order = Guid.NewGuid(),
                TotalPaid = 232,
                Tax = Guid.NewGuid(),
            }
        };
        
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