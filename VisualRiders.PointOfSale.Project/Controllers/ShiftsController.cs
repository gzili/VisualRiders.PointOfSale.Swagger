using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("api/shifts")]
public class ShiftsController : ControllerBase
{
    [HttpPost]
    public ActionResult<Shift> Create(CreateUpdateShiftDto dto)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public List<Shift> GetAll()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id:guid}")]
    public ActionResult<Shift> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id:guid}")]
    public ActionResult<Shift> Update(Guid id, CreateUpdateShiftDto dto)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:guid}")]
    public ActionResult<Shift> Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}