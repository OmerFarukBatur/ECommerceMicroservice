using Application.DTOs;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return _repo.GetAll().Select(p => new CategoryDto
            {
                Id = p.Id,
                Name = p.Name
            });
        }

        public CategoryDto? GetCategoryById(int id)
        {
            var category = _repo.GetById(id);
            if (category == null) return null;

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public void CreateCategory(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name
            }; 

            _repo.Add(category);
        }

        public void UpdateCategory(CategoryDto categoryDto)
        {
            var category = _repo.GetById(categoryDto.Id);
            if (category == null)
                throw new ArgumentException("Category not found.");

            category.Name = categoryDto.Name;

            _repo.Update(category);
        }
        public void DeleteCategory(int id) => _repo.Delete(id);
    }
}
