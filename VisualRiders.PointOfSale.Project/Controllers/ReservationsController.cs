using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers;

[ApiController]
[Route("api/reservations")]
[Produces("application/json")]
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

    /// <summary>
    /// Retrieves all time slots, filtered by specified criteria
    /// </summary>
    /// <param name="employeeId">Allows to filter time slots by employee</param>
    /// <param name="serviceId">Allows to filter time slots by service</param>
    /// <param name="startTimeFrom">
    /// If provided, only includes time slots that have a start time equal or greater than the time specified (minute precision)
    /// </param>
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns a list of time slots that match the specified criteria")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "If any of the parameters have invalid format")]
    public List<Reservation> GetAll(Guid? employeeId, Guid? serviceId, DateTime? startTimeFrom)
    {
        return _reservationsRepository.GetAll();
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
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

    /// <summary>
    /// Book a time slot for a currently logged in customer
    /// </summary>
    /// <param name="id">The ID of the time slot (reservation) to book</param>
    [HttpPost("{id:guid}/book")]
    [SwaggerResponse(StatusCodes.Status200OK, "Returns an object describing if the booking was successful")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The specified time slot does not exist")]
    public BookReservationResponseDto Book(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
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