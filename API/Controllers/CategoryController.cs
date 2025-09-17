using Application.DTOs;
using Application.Services;
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
        public IActionResult Create(CategoryDto categoryDto)
        {
            _service.CreateCategory(categoryDto);
            return Ok(categoryDto);
        }

        [HttpPut]
        public IActionResult Update(CategoryDto categoryDto)
        {
            _service.UpdateCategory(categoryDto);
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