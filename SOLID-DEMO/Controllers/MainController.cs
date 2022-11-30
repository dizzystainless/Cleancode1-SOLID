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
public class MainController : ControllerBase
{
    private readonly ICustomer _customer;

    public MainController(ICustomer customer)
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
        await _customer.AddUser(customer);
        return Ok();
    }

    //    [HttpPost("/customers/login")]
    //    public async Task<IActionResult> LoginCustomer(string email, string password)
    //    {
    //        var customer = await _shopContext.Customers.FirstOrDefaultAsync(c => c.Name.Equals(email) && c.Password.Equals(password));
    //        if (customer is not null)
    //        {
    //            return Ok();
    //        }
    //        return BadRequest();
    //    }

    //    [HttpDelete("/customers/delete/{id}")]
    //    public async Task<IActionResult> DeleteCustomer(int id)
    //    {
    //        var customer = await _shopContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
    //        if (customer is null) return BadRequest();

    //        _shopContext.Customers.Remove(customer);
    //        await _shopContext.SaveChangesAsync();
    //        return Ok();
    //    }

    //    [HttpGet("/products")]
    //    public async Task<IActionResult> GetProducts()
    //    {
    //        return Ok(await _shopContext.Products.ToListAsync());
    //    }

    //    [HttpGet("/products/{id}")]
    //    public async Task<IActionResult> GetProduct(int id)
    //    {
    //        return Ok(await _shopContext.Products.FirstOrDefaultAsync(c => c.Name.Equals(id)));
    //    }

    //    [HttpPost("/products")]
    //    public async Task<IActionResult> AddProduct(Product newProd)
    //    {
    //        var prod = await _shopContext.Products.FirstOrDefaultAsync(p => p.Name.Equals(newProd.Name));
    //        if (prod == null)
    //        {
    //            await _shopContext.Products.AddAsync(newProd);
    //            await _shopContext.SaveChangesAsync();
    //            return Ok();
    //        }

    //        return BadRequest();
    //    }

    //    [HttpGet("/orders")]
    //    public async Task<IActionResult> GetAllOrders()
    //    {
    //        var orders = await _shopContext.Orders.Include(o=> o.Customer).Include(o=>o.Products).ToListAsync();
    //        return Ok(orders);
    //    }

    //    [HttpGet("/orders/customer/{id}")]
    //    public async Task<IActionResult> GetOrdersForCustomer(int id)
    //    {
    //        var orders = await _shopContext.Orders.Include(o=>o.Customer).Where(c=> c.Customer.Id == id).Include(o=>o.Products).ToListAsync();
    //        if (orders.Count == 0)
    //        {
    //            return NotFound();
    //        }
    //        return Ok(orders);
    //    }

    //    [HttpPost("/orders")]
    //    public async Task<IActionResult> PlaceOrder(CustomerCart cart)
    //    {
    //        var customer = await _shopContext.Customers.FirstOrDefaultAsync(c => c.Id.Equals(cart.CustomerId));
    //        if (customer is null)
    //        {
    //            return BadRequest();
    //        }

    //        var products = new List<Product>();

    //        foreach (var prodId in cart.ProductIds)
    //        {
    //            var prod = await _shopContext.Products.FirstOrDefaultAsync(p => p.Id == prodId);
    //            if (prod is null)
    //            {
    //                return NotFound();
    //            }
    //            products.Add(prod);
    //        }

    //        var order = new Order() {Customer = customer, Products = products};
    //        var now = DateTime.Now;
    //        order.ShippingDate = now.AddDays(5);

    //        await _shopContext.Orders.AddAsync(order);
    //        await _shopContext.SaveChangesAsync();

    //        return Ok();
    //    }

    //    [HttpDelete("/orders/{id}")]
    //    public async Task<IActionResult> CancelOrder(int id)
    //    {
    //        var order = await _shopContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
    //        if (order is null)
    //        {
    //            return NotFound();
    //        }

    //        _shopContext.Orders.Remove(order);
    //        await _shopContext.SaveChangesAsync();
    //        return Ok();
    //    }

    //    [HttpPatch("order/add/{id}")]
    //    public async Task<IActionResult> AddToOrder(CustomerCart itemsToAdd, int id)
    //    {
    //        var customer = await _shopContext.Customers.FirstOrDefaultAsync(c => c.Id.Equals(itemsToAdd.CustomerId));
    //        if (customer is null)
    //        {
    //            return BadRequest();
    //        }

    //        var products = new List<Product>();

    //        foreach (var prodId in itemsToAdd.ProductIds)
    //        {
    //            var prod = await _shopContext.Products.FirstOrDefaultAsync(p => p.Id == prodId);
    //            if (prod is null)
    //            {
    //                return NotFound();
    //            }
    //            products.Add(prod);
    //        }

    //        var order = await _shopContext.Orders.Include(o => o.Customer).Include(o => o.Products).FirstOrDefaultAsync(o => o.Id == id);
    //        order.ShippingDate = DateTime.Now.AddDays(5);
    //        order.Products.AddRange(products);
    //        await _shopContext.SaveChangesAsync();

    //        return Ok();
    //    }

    //    [HttpPatch("order/remove/{id}")]
    //    public async Task<IActionResult> RemoveFromOrder(CustomerCart itemsToRemove, int id)
    //    {
    //        var customer = await _shopContext.Customers.FirstOrDefaultAsync(c => c.Id.Equals(itemsToRemove.CustomerId));
    //        if (customer is null)
    //        {
    //            return BadRequest();
    //        }

    //        var order = await _shopContext.Orders.Include(o => o.Customer.Id == customer.Id).Include(o => o.Products).FirstOrDefaultAsync(o => o.Id == id);
    //        order.ShippingDate = DateTime.Now.AddDays(5);

    //        foreach (var prodId in itemsToRemove.ProductIds)
    //        {
    //            var prod =  order.Products.FirstOrDefault(p => p.Id == prodId);
    //            if (prod is null)
    //            {
    //                continue;
    //            }
    //            order.Products.Remove(prod);
    //        }

    //        await _shopContext.SaveChangesAsync();

    //        return Ok();
    //    }
}