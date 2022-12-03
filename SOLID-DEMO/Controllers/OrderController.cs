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

            //var products = new List<Product>();

            //foreach (var prodId in cart.ProductIds)
            //{
            //    //var prod = await _shopContext.Products.FirstOrDefaultAsync(p => p.Id == prodId);
            //    if (prod is null)
            //    {
            //        return NotFound();
            //    }
            //    products.Add(prod);
            //}
            var products = await _order.AddToCartAsync(cart);

            var order = new Order() { Customer = customer, Products = products };

            await _order.CreateOrderAsync(order);
            //var now = DateTime.Now;
            //order.ShippingDate = now.AddDays(5);

            //await _shopContext.Orders.AddAsync(order);
            //await _shopContext.SaveChangesAsync();

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
            //var customer = await _shopContext.Customers.FirstOrDefaultAsync(c => c.Id.Equals(itemsToAdd.CustomerId));
            var customer = await _order.GetCustomerForItemsToAddAsync(itemsToAdd, id);
            if (customer is null)
            {
                return BadRequest();
            }

            //var products = new List<Product>();

            //foreach (var prodId in itemsToAdd.ProductIds)
            //{
            //    var prod = await _shopContext.Products.FirstOrDefaultAsync(p => p.Id == prodId);
            //    if (prod is null)
            //    {
            //        return NotFound();
            //    }
            //    products.Add(prod);
            //}
            var products = await _order.GetItemsToAddAsync(itemsToAdd);

            var order = await _order.GetOrderToAddItemsAsync(id);

            //        order.ShippingDate = DateTime.Now.AddDays(5);
            //        order.Products.AddRange(products);
            //        await _shopContext.SaveChangesAsync();
            await _order.AddToOrderAsync(order, products);

            return Ok();
        }

        [HttpPatch("order/remove/{id}")]
        public async Task<IActionResult> RemoveFromOrder(CustomerCart itemsToRemove, int id)
        {
            //var customer = await _shopContext.Customers.FirstOrDefaultAsync(c => c.Id.Equals(itemsToRemove.CustomerId));
            var customer = await _order.GetCustomerForItemsToRemoveAsync(itemsToRemove, id);
            if (customer is null)
            {
                return BadRequest();
            }

            //var order = await _shopContext.Orders.Include(o => o.Customer.Id == customer.Id).Include(o => o.Products).FirstOrDefaultAsync(o => o.Id == id);
            var order = await _order.GetOrderToRemoveItemsAsync(id);

            //order.ShippingDate = DateTime.Now.AddDays(5);

            //foreach (var prodId in itemsToRemove.ProductIds)
            //{
            //    var prod = order.Products.FirstOrDefault(p => p.Id == prodId);
            //    if (prod is null)
            //    {
            //        continue;
            //    }
            //    order.Products.Remove(prod);
            //}

            await _order.RemoveFromOrderAsync(itemsToRemove, order);
            //await _shopContext.SaveChangesAsync();

            return Ok();
        }
    }
}

