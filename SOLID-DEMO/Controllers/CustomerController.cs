
using Microsoft.AspNetCore.Mvc;
using Server.UnitOfWork;

namespace Server.Controllers;


[ApiController]
[Route("/api")]
public class CustomerController : ControllerBase
{
    //private readonly ICustomerService _customer;

    //public CustomerController(ICustomerService customer)
    //{
    //    _customer = customer;
    //}

    private readonly IUnitOfWork _unitOfWork;
    public CustomerController(IUnitOfWork work)
    {
        _unitOfWork = work;
    }

    [HttpGet("/customers")]
    public async Task<IActionResult> GetAll()
    {
        var data = await _unitOfWork.customerService.GetAllAsync();
        return Ok(data);
    }

    [HttpGet("customers/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _unitOfWork.customerService.GetByIdAsync(id);
        return Ok(data);
    }










    //[HttpGet("/customers/{email}")]
    //public async Task<IActionResult> GetCustomer(string email)
    //{
    //    var customer = await _customer.GetCustomerByEmailAsync(email);
    //    if (customer is null) return NotFound($"No customer found with email: {email}");
    //    return Ok(customer);
    //}

    //[HttpPost("/customers/register")]
    //public async Task<IActionResult> RegisterUser(Customer customer)
    //{
    //    if (!customer.Name.Contains("@"))
    //        throw new ValidationException("Email is not an email");
    //    await _customer.RegisterCustomerAsync(customer);
    //    return Ok();
    //}

    //[HttpPost("/customers/login")]
    //public async Task<IActionResult> LoginCustomer(string email, string password)
    //{
    //    var customer = await _customer.LoginCustomerAsync(email, password);
    //    if (customer is not null)
    //    {
    //        return Ok();
    //    }
    //    return BadRequest();
    //}

    //[HttpDelete("/customers/delete/{id}")]
    //public async Task<IActionResult> DeleteCustomer(int id)
    //{
    //    var customer = await _customer.GetCustomerByIdAsync(id); ;
    //    if (customer is null) return BadRequest();
    //    await _customer.DeleteCustomerAsync(customer);
    //    return Ok();
    //}
}