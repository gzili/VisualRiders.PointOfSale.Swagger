using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Enums;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class BranchesRepository
{
    private static readonly List<Branch> _branches = Data.Branches;
    private static readonly List<Company> _companies = Data.Companies;
    public Branch Create(CreateUpdateBranchDto dto)
    {
        var company = _companies.Find(c => c.Id == dto.CompanyId);
        
        var branch = new Branch
        {
            Id = Guid.NewGuid(),
            Address = dto.Address,
            BranchStatus = dto.BranchStatus,
            Company = company,
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
        return _branches.Find(b => b.Id == id);
    }

    public void Update(Branch branch, CreateUpdateBranchDto dto)
    {
        var company = _companies.Find(c => c.Id == dto.CompanyId);
        
        branch.Address = dto.Address;
        branch.Contacts = dto.Contacts;
        branch.BranchStatus = dto.BranchStatus;
        branch.Company = company;
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