using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;

namespace Server.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;

       
        public ProductController(IProduct product)
        {
            _product = product;
        }

        [HttpGet("/products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _product.GetAllProductsAsync();
            return Ok(products);
        }

        //[HttpGet("/products/{id}")]
        //public async Task<IActionResult> GetProduct(int id)
        //{
        //    return Ok(await _shopContext.Products.FirstOrDefaultAsync(c => c.Name.Equals(id)));
        //}

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


    }
}
