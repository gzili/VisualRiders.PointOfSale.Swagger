using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Enums;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class BranchesRepository
{
    private static readonly List<Branch> _branches = new()
    {
        new Branch {
            Id = Guid.NewGuid(),
            Address = "Address",
            BranchStatus = BranchStatus.Active,
            CompanyId = Guid.NewGuid(),
            Contacts = "email@domain.com",
            WorkingDays = WorkingDays.Monday | WorkingDays.Friday,
            WorkingHourEnd = new TimeSpan(8,0,0),
            WorkingHourStart = new TimeSpan(17,30,0)
        },
        new Branch {
            Id = Guid.NewGuid(),
            Address = "Address2",
            BranchStatus = BranchStatus.Active,
            CompanyId = Guid.NewGuid(),
            Contacts = "email2@domain.com",
            WorkingDays = WorkingDays.Monday | WorkingDays.Friday,
            WorkingHourEnd = new TimeSpan(8,0,0),
            WorkingHourStart = new TimeSpan(18,0,0)
        }
    };
    public Branch Create(CreateUpdateBranchDto dto)
    {
        var branch = new Branch
        {
            Id = Guid.NewGuid(),
            Address = dto.Address,
            BranchStatus = dto.BranchStatus,
            CompanyId = dto.CompanyId,
            Contacts = dto.Contacts,
            WorkingDays = dto.WorkingDays,
            WorkingHourEnd = dto.WorkingHourEnd,
            WorkingHourStart = dto.WorkingHourStart
        };
        
        _branches.Add(branch);
        return branch;
    }

    public List<Branch> GetAll()
    {
        return _branches;
    }

    public Branch? GetById(Guid id)
    {
        foreach (var branch  in _branches)
        {
            System.Diagnostics.Debug.WriteLine(branch.Id);
        }
        System.Diagnostics.Debug.WriteLine("provided" + id);
        return _branches.Find(b => b.Id == id);
    }

    public void Update(Branch branch, CreateUpdateBranchDto dto)
    {
        branch.Address = dto.Address;
        branch.Contacts = dto.Contacts;
        branch.BranchStatus = dto.BranchStatus;
        branch.CompanyId = dto.CompanyId;
        branch.WorkingDays = dto.WorkingDays;
        branch.WorkingHourStart = dto.WorkingHourStart;
        branch.WorkingHourEnd = dto.WorkingHourEnd;
    }

    public void Delete(Branch branch)
    {
        _branches.Remove(branch);
    }

    public void UpdateWorkingHours(Branch branch, UpdateBranchWorkingHoursDto dto)
    {
        branch.WorkingHourStart = dto.WorkingHourStart;
        branch.WorkingHourEnd = dto.WorkingHourEnd;
    }
    
    public void UpdateContacts(Branch branch, UpdateBranchContactsDto dto)
    {
        branch.Contacts = dto.Contacts;
    }
}