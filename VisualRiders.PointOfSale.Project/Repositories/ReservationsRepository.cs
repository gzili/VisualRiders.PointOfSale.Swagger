using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class ReservationsRepository
{
    private readonly OrdersRepository _ordersRepository;
    private readonly ServicesRepository _servicesRepository;
    private readonly EmployeesRepository _employeesRepository;
    
    private readonly List<Reservation> _reservations = Data.Reservations;

    public ReservationsRepository(OrdersRepository ordersRepository, ServicesRepository servicesRepository, EmployeesRepository employeesRepository)
    {
        _ordersRepository = ordersRepository;
        _servicesRepository = servicesRepository;
        _employeesRepository = employeesRepository;
    }
    public Reservation Create(CreateUpdateReservationDto dto)
    {
        //var order = _ordersRepository.
        var service = _servicesRepository.GetById(dto.ServiceId);
        var employee = _employeesRepository.GetById(dto.EmployeeId);
        var reservation = new Reservation()
        {
            Id = Guid.NewGuid(),
            Employee = employee,
            EndTime = dto.EndTime,
            Order = dto.OrderId,
            ReservationStatus = dto.ReservationStatus,
            Service = service,
            StartTime = dto.StartTime,
        };
        _reservations.Add(reservation);
        return reservation;
    }
    
    public void Update(Reservation reservation, CreateUpdateReservationDto dto)
    {
        //var order = _ordersRepository.
        var service = _servicesRepository.GetById(dto.ServiceId);
        var employee = _employeesRepository.GetById(dto.EmployeeId);

        reservation.Id = Guid.NewGuid();
        reservation.Employee = employee;
        reservation.EndTime = dto.EndTime;
        reservation.Order = dto.OrderId;
        reservation.ReservationStatus = dto.ReservationStatus;
        reservation.Service = service;
        reservation.StartTime = dto.StartTime;
    }
    
    public Reservation? GetById(Guid id)
    {
        return _reservations.Find(r => r.Id == id);
    }
    
    public void Delete(Reservation reservation)
    {
        _reservations.Remove(reservation);
    }

    public List<Reservation> GetAll()
    {
        return _reservations;
    }
}
