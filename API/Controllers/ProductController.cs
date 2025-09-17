using Application.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAllProducts());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _service.GetProductById(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _service.CreateProduct(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            if (id != product.Id) return BadRequest();
            _service.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteProduct(id);
            return NoContent();
        }
    }
}
