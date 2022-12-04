using VisualRiders.PointOfSale.Project.Dto;
using VisualRiders.PointOfSale.Project.Enums;
using VisualRiders.PointOfSale.Project.Models;

namespace VisualRiders.PointOfSale.Project.Repositories;

public class CustomersRepository
{
    private static List<Customer> _customersRepository = new()
    {
        new()
        {
            Id = Guid.NewGuid(),
            Name = "UserName 1",
            Email = "user1@mail.com",
            Password = "Secret so do not tell 1",
            PhoneNumber = "000 000 0001",
            RegisterDate = new DateTime(2022,11,5),
            Status = Enums.CustomerStatus.Active,
            DiscountId = Guid.NewGuid()
        },
        new ()
        {
            Id = Guid.NewGuid(),
            Name = "UserName 2",
            Email = "user2@mail.com",
            Password = "Secret so do not tell 2",
            PhoneNumber = "000 000 0002",
            RegisterDate = new DateTime(2022,9,5),
            Status = Enums.CustomerStatus.Deleted,
            DiscountId = Guid.NewGuid()
        }
    };

    public Customer Create(CreateCustomerDto customerDto)
    {
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            Name = customerDto.Name,
            Email = customerDto.Email,
            Password = customerDto.Password,
            PhoneNumber = customerDto.PhoneNumber,
            RegisterDate = DateTime.Now,
            Status = CustomerStatus.Active
        };

        _customersRepository.Add(customer);

        return customer;

    }

    public Customer? GetById(Guid id) => _customersRepository.Find(c => c.Id == id);

    public Customer? GetByCredentials(CustomerCredentialsDto dto)
    {
        return _customersRepository.Find(c => (c.Name == dto.Email) && (c.Password == dto.Password));
    }

    public void Delete(Customer customer) 
    {
        _customersRepository.Remove(customer);
    }
}