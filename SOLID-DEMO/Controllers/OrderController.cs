using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.UnitOfWork;
using Shared;

namespace Server.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderController(IUnitOfWork work)
        {
            _unitOfWork = work;
        }

        [HttpGet("/orders")]
        public async Task<IActionResult> GetAll()
        { 
            var data = await _unitOfWork.orderService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("/orders/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _unitOfWork.orderService.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpGet("/orders/customer/")]
        public async Task<IActionResult> GetAllById(int customerid)
        {
            var data = await _unitOfWork.orderService.GetAllByIdAsync(customerid);
            return Ok(data);
        }

        //[HttpPost("/orders")]
        //public async Task<IActionResult> PlaceOrder(CustomerCart cart)
        //{
        //    var customer = await _order.GetCustomerCartAsync(cart);

        //    if (customer is null)
        //    {
        //        return BadRequest();
        //    }
        //    var products = await _order.AddToCartAsync(cart);
        //    var order = new Order() { Customer = customer, Products = products };
        //    await _order.CreateOrderAsync(order);
        //    return Ok();
        //}

        [HttpDelete("/orders/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _unitOfWork.orderService.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return Ok(data);
        }

        //[HttpPatch("order/add/{id}")]
        //public async Task<IActionResult> AddToOrder(CustomerCart itemsToAdd, int id)
        //{
        //    var customer = await _order.GetCustomerForItemsToAddAsync(itemsToAdd, id);

        //    if (customer is null)
        //    {
        //        return BadRequest();
        //    }
        //    var products = await _order.GetItemsToAddAsync(itemsToAdd);
        //    var order = await _order.GetOrderByCustomerAsync(id);
        //    await _order.AddToOrderAsync(order, products);
        //    return Ok();
        //}

        //[HttpPatch("order/remove/{id}")]
        //public async Task<IActionResult> RemoveFromOrder(CustomerCart itemsToRemove, int id)
        //{
        //    var customer = await _order.GetCustomerForItemsToRemoveAsync(itemsToRemove, id);

        //    if (customer is null)
        //    {
        //        return BadRequest();
        //    }
        //    var order = await _order.GetOrderByCustomerAsync(id);
        //    await _order.RemoveFromOrderAsync(itemsToRemove, order);
        //    return Ok();
        //}
    }
}

