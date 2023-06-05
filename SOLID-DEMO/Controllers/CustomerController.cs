﻿
using Microsoft.AspNetCore.Mvc;
using Server.UnitOfWork;
using Shared;

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
    //public async Task<IActionResult> GetByEmail(string email)
    //{
    //    var data = await _unitOfWork.customerService.GetByEmailAsync(email);
    //    return Ok(data);
    //}

    [HttpPost("/customers/create")]
    public async Task<IActionResult> Create(Customer customer)
    {
        var data = await _unitOfWork.customerService.CreateAsync(customer);
        await _unitOfWork.CompleteAsync();
        return Ok(data);
    }

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