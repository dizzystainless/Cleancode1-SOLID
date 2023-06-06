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

        [HttpGet("/products")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _unitOfWork.productService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("/products/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _unitOfWork.productService.GetByIdAsync(id);
            return Ok(data);
        }

        [HttpPost("/products/create")]
        public async Task<IActionResult> Create(Product product)
        {
            var data = await _unitOfWork.productService.CreateAsync(product);
            await _unitOfWork.CompleteAsync();
            return Ok(data);
        }

        [HttpDelete("/products/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _unitOfWork.productService.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return Ok(data);
        }
    }
}
