using System.Globalization;
using VisualRiders.PointOfSale.Project.Enums;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project;

public class Data
{
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
                CompanyStatus = CompanyStatus.Active
            },
            new Company()
            {
                Id = Guid.NewGuid(),
                Name = "Company2",
                ActiveSince = new DateTime(2022, 11, 07).ToString(CultureInfo.InvariantCulture),
                LegalCompanyName = "Company2",
                BillingDetails = "details",
                CompanyStatus = CompanyStatus.Active
            }
        };
        Branches = new()
        {
            new Branch {
                Id = Guid.NewGuid(),
                Address = "Address",
                BranchStatus = BranchStatus.Active,
                Company = Companies[0],
                Contacts = "email@domain.com",
                WorkingDays = WorkingDays.Monday | WorkingDays.Friday,
                WorkingHourEnd = new Time{ Hours = 8, Minutes = 0 },
                WorkingHourStart = new Time{ Hours = 17, Minutes = 30 },
            },
            new Branch {
                Id = Guid.NewGuid(),
                Address = "Address2",
                BranchStatus = BranchStatus.Active,
                Company = Companies[1],
                Contacts = "email2@domain.com",
                WorkingDays = WorkingDays.Monday | WorkingDays.Friday,
                WorkingHourEnd = new Time{ Hours = 8, Minutes = 0 },
                WorkingHourStart = new Time{ Hours = 17, Minutes = 0 },
            }
        };
    }
}