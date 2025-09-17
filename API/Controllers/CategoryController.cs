using Application.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _service;

        public CategoryController(CategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAllCategories());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _service.GetCategoryById(id);
            return category == null ? NotFound() : Ok(category);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _service.CreateCategory(category);
            return Ok(category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Category category)
        {
            if (id != category.Id) return BadRequest();
            _service.UpdateCategory(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteCategory(id);
            return NoContent();
        }
    }
}