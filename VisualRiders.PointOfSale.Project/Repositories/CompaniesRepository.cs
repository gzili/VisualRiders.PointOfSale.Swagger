using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Enums;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class CompaniesRepository
{
    private readonly List<Company> _companies = Data.Companies;

    public Company Create(CreateUpdateCompanyDto dto)
    {
        var company = new Company
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            ActiveSince = dto.ActiveSince,
            BillingDetails = dto.BillingDetails,
            Status = CompanyStatus.Active,
            LegalCompanyName = dto.LegalCompanyName
        };
        
        _companies.Add(company);

        return company;
    }

    public Company? GetById(Guid id)
    {
        return _companies.Find(p => p.Id == id);
    }

    public List<Company> GetAll()
    {
        return _companies;
    }

    public void Update(Company company, CreateUpdateCompanyDto dto)
    {
        company.Name = dto.Name;
        company.ActiveSince = dto.ActiveSince;
        company.BillingDetails = dto.BillingDetails;
        company.LegalCompanyName = dto.LegalCompanyName;
    }

    public void Delete(Company company)
    {
        _companies.Remove(company);
    }
}