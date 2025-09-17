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

        public IEnumerable<Category> GetAllCategories() => _repo.GetAll();
        public Category? GetCategoryById(int id) => _repo.GetById(id);

        public void CreateCategory(Category category)
        {
            _repo.Add(category);
        }

        public void UpdateCategory(Category category) => _repo.Update(category);
        public void DeleteCategory(int id) => _repo.Delete(id);
    }
}
