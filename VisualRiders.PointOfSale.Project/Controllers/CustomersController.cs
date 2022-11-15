﻿using Microsoft.AspNetCore.Mvc;
using VisualRiders.PointOfSale.Project.DTOs;
using VisualRiders.PointOfSale.Project.Models;
using VisualRiders.PointOfSale.Project.Repositories;

namespace VisualRiders.PointOfSale.Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomersRepository _customersRepository;

        public CustomersController(CustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Customer> Create(CreateCustomerDto customerDto)
        {
            var customer = _customersRepository.Create(customerDto);

            return CreatedAtAction("GetById", new { id = customer.Id}, customer);
        }

        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Customer> GetByCredentials(CustomerCredentialsDto customerCredentialsDto) 
        {
            var customer = _customersRepository.GetByCredentials(customerCredentialsDto);

            if(customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        //public void GetOrderHistory() { }
        //public void AddDiscount() { }
        //public void Update() { }  //not mentioned at all...

        [HttpDelete]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(CustomerCredentialsDto customerCredentialsDto)
        {
            var customer = _customersRepository.GetByCredentials(customerCredentialsDto);

            if (customer == null)
            {
                return NotFound();
            }

            _customersRepository.Delete(customer);

            return Ok();
        }
    }
}
