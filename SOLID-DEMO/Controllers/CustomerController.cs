using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared;
using System.ComponentModel.DataAnnotations;
using Server.DataAccess;
using Server.Interfaces;

namespace Server.Controllers;

[ApiController]
[Route("/api")]
public class CustomerController : ControllerBase
{
    private readonly ICustomer _customer;

    public CustomerController(ICustomer customer)
    {
        _customer = customer;
    }

    [HttpGet("/customers")]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _customer.GetAllCustomersAsync();
        return Ok(customers);
    }

    [HttpGet("/customers/{email}")]
    public async Task<IActionResult> GetCustomer(string email)
    {
        var customer = await _customer.GetCustomerByEmailAsync(email);
        if (customer is null) return NotFound($"No customer found with email: {email}");
        return Ok(customer);
    }

    [HttpPost("/customers/register")]
    public async Task<IActionResult> RegisterUser(Customer customer)
    {
        if (!customer.Name.Contains("@"))
            throw new ValidationException("Email is not an email");
        await _customer.RegisterCustomerAsync(customer);
        return Ok();
    }

    [HttpPost("/customers/login")]
    public async Task<IActionResult> LoginCustomer(string email, string password)
    {
        var customer = await _customer.LoginCustomerAsync(email, password);
        if (customer is not null)
        {
            return Ok();
        }
        return BadRequest();
    }

    [HttpDelete("/customers/delete/{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customer = await _customer.GetCustomerByIdAsync(id); ;
        if (customer is null) return BadRequest();
        await _customer.DeleteCustomerAsync(customer);
        return Ok();
    }
}