using Microsoft.AspNetCore.Mvc;
using Lab2.CommonModules.Interface;
using Lab2.CommonModules.Entity;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productService;

        public ProductController(IProduct productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var result = await _productService.Add(product);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct([FromBody] Product product)
        {
            var result = await _productService.Get(product);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var result = await _productService.Update(product);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct([FromBody] Product product)
        {
            var result = await _productService.Delete(product);
            return Ok(result);
        }
    }
}
