using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Shared;

namespace Server.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly IOrder _order;
        public OrderController(IOrder order)
        {
            _order = order;
        }

        [HttpGet("/orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _order.GetAllOrderssAsync();
            return Ok(orders);
        }

        [HttpGet("/orders/customer/{id}")]
        public async Task<IActionResult> GetOrdersForCustomer(int id)
        {
            var orders = await _order.GetOrdersByCustomerAsync(id);

            if (orders.Count == 0)
            {
                return NotFound();
            }
            return Ok(orders);
        }

        [HttpPost("/orders")]
        public async Task<IActionResult> PlaceOrder(CustomerCart cart)
        {
            var customer = await _order.GetCustomerCartAsync(cart);

            if (customer is null)
            {
                return BadRequest();
            }
            var products = await _order.AddToCartAsync(cart);
            var order = new Order() { Customer = customer, Products = products };
            await _order.CreateOrderAsync(order);
            return Ok();
        }

        [HttpDelete("/orders/{id}")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var order = await _order.GetOrderByIdAsync(id);

            if (order is null)
            {
                return NotFound();
            }
            await _order.CancelOrderAsync(order);
            return Ok();
        }

        [HttpPatch("order/add/{id}")]
        public async Task<IActionResult> AddToOrder(CustomerCart itemsToAdd, int id)
        {
            var customer = await _order.GetCustomerForItemsToAddAsync(itemsToAdd, id);

            if (customer is null)
            {
                return BadRequest();
            }
            var products = await _order.GetItemsToAddAsync(itemsToAdd);
            var order = await _order.GetOrderByCustomer(id);
            await _order.AddToOrderAsync(order, products);
            return Ok();
        }

        [HttpPatch("order/remove/{id}")]
        public async Task<IActionResult> RemoveFromOrder(CustomerCart itemsToRemove, int id)
        {
            var customer = await _order.GetCustomerForItemsToRemoveAsync(itemsToRemove, id);

            if (customer is null)
            {
                return BadRequest();
            }
            var order = await _order.GetOrderByCustomer(id);
            await _order.RemoveFromOrderAsync(itemsToRemove, order);
            return Ok();
        }
    }
}

