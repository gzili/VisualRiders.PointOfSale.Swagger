using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationsController : ControllerBase
{
    private readonly ReservationsRepository _reservationsRepository;

    public ReservationsController(ReservationsRepository reservationsRepository)
    {
        _reservationsRepository = reservationsRepository;
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<Reservation> Create(CreateUpdateReservationDto dto)
    {
        var reservation = _reservationsRepository.Create(dto);
        return CreatedAtAction("GetById", new { id = reservation.Id }, reservation);
    }

    [HttpGet]
    public List<Reservation> GetAll()
    {
        return _reservationsRepository.GetAll();
    }

    [HttpGet("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Reservation> GetById(Guid id)
    {
        var reservation = _reservationsRepository.GetById(id);

        if (reservation == null)
        {
            return NotFound();
        }

        return reservation;
    }
    
    [HttpGet("{employeeId:guid}/{date:datetime}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public List<Reservation> GetByIdAndDate(Guid employeeId, DateTime date)
    {
        var reservations = _reservationsRepository.GetAll().FindAll(r => r.Employee.Id == employeeId && r.StartTime.Month == date.Month && r.StartTime.Year == date.Year && r.StartTime.Day == date.Day );

        return reservations;
    }
    
    [HttpPut("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Reservation> Update(Guid id, CreateUpdateReservationDto dto)
    {
        var reservation = _reservationsRepository.GetById(id);
        
        if (reservation == null)
        {
            return NotFound();
        }
        
        _reservationsRepository.Update(reservation, dto);
        
        return reservation;
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(Guid id)
    {
        var reservation = _reservationsRepository.GetById(id);
        
        if (reservation == null)
        {
            return NotFound();
        }

        _reservationsRepository.Delete(reservation);

        return Ok();
    }
}