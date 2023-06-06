using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.UnitOfWork;
using Shared;

namespace Server.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork work)
        {
            _unitOfWork = work;
        }

        //[HttpGet("/products")]
        //public async Task<IActionResult> GetProducts()
        //{
        //    var products = await _product.GetAllProductsAsync();
        //    return Ok(products);
        //}

        //[HttpGet("/products/{id}")]
        //public async Task<IActionResult> GetProduct(int id)
        //{
        //    var product = await _product.GetProductByIdAsync(id);
        //    if (product is null) return NotFound($"No product found with id: {id}");
        //    return Ok(product);
        //}

        //[HttpPost("/products")]
        //public async Task<IActionResult> AddProduct(Product newProd)
        //{
        //    var prod = await _product.GetNewProductByNameAsync(newProd);
        //    if (prod == null)
        //    {
        //        await _product.AddProductAsync(newProd);
        //        return Ok();
        //    }
        //    return BadRequest();
    //}
    }
}
