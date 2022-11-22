using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private ReportsRepository _reportsRepository;
    
    public ReportsController(ReportsRepository reportsRepository)
    {
        _reportsRepository = reportsRepository;
    }
    
    [HttpGet("/api/Reports/Receipts")]
    public List<Receipt> GetAll()
    {
        return _reportsRepository.GetByCustomer();
    }

    [HttpGet("/api/Reports/Receipts/{branchId:guid}")]
    public List<Receipt> GetByBranch(Guid branchId)
    {
        return _reportsRepository.GetByCustomer();
    }
    
    [HttpGet("/api/Reports/Sales/{branchId:guid}")]
    public ActionResult<SalesAnalysis> GetSalesAnalysis(Guid branchId, [FromQuery] SalesAnalysisDto dto)
    {
        return _reportsRepository.GetSalesAnalysis();
    }
}